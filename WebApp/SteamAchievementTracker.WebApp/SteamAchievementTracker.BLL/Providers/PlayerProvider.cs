using SteamAchievementTracker.BLL.Converters.ServiceToModel;
using SteamAchievementTracker.Contracts.Providers;
using SteamApiWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.BulkInsert.Extensions;


namespace SteamAchievementTracker.BLL.Providers
{
    public class PlayerProvider : BaseProvider, IPlayerProfileService
    {

        private DataAccess.ModelContext db;

        public PlayerProvider()
        {
            //TODO: _pRepo == data access repo
            db = new DataAccess.ModelContext();
        }


        public async Task<Contracts.Models.IPlayerProfile> GetProfileFromLogin(long steamId)
        {
            DataAccess.Models.PlayerProfile profile = new DataAccess.Models.PlayerProfile();
            profile = db.PlayerProfiles.Where(x => x.SteamId == steamId).FirstOrDefault();

            if (profile == null || ExperationService.isProfileExpired(profile.LastUpdate))
            {



                var profileTask = ProcessProfile(steamId, profile);
                var recentGameTask = ProcessRecentGames(steamId);
                await Task.WhenAll(profileTask, recentGameTask);

                profile = await profileTask;
                profile.LastUpdate = DateTime.Now;
                db.SaveChangesAsync();


            }


            //////Update Library
            if (profile.LibraryLastUpdate < Settings.ProfileExpiration)
            {
                await UpdateLibrary(steamId);
                profile.LibraryLastUpdate = DateTime.Now;
                db.SaveChanges();
            }

            db.Dispose();
            return profile;
        }




        private async Task<DataAccess.Models.PlayerProfile> ProcessProfile(long steamId, DataAccess.Models.PlayerProfile profile)
        {
            var request = new SteamApiWrapper.SteamUser.GetPlayerSummariesRequest(base.APIKey);
            request.ProfileIds = new List<long>();
            request.ProfileIds.Add(steamId);

            var response = await request.GetResponse();

            if (response == null || response.Players == null)
            {
                //Throw new exception

            }


            var player = response.Players.FirstOrDefault();
            if (profile == null)
            {
                profile = AddProfile(player);
                db.PlayerProfiles.Add(profile);
            }
            else
            {
                profile.ConvertService(player);
            }
            return profile;
        }


        private async Task UpdateLibrary(long steamId)
        {

            var gRequest = new SteamApiWrapper.PlayerService.GetOwnedGamesRequest(base.APIKey);

            gRequest.SteamId = steamId;
            gRequest.include_appinfo = "1";
            gRequest.include_played_free_games = "1";
            var gResponse = await gRequest.GetResponse();

            InsertUpdateGames(steamId, gResponse.OwnedGames);
        }

        private async Task ProcessRecentGames(long steamId)
        {
            var rgRequest = new SteamApiWrapper.PlayerService.GetRecentlyPlayedGamesRequest(base.APIKey);

            rgRequest.SteamId = steamId;
            var recentGamesResponse = await rgRequest.GetResponse();

            if (recentGamesResponse.RecentlyPlayedGames != null)
            {
                var oldRecentGames = db.ProfileRecentGames.Where(x => x.SteamId == steamId);
                db.ProfileRecentGames.RemoveRange(oldRecentGames);
                db.SaveChanges();


                var recentGames = new List<DataAccess.Models.ProfileRecentGame>();
                foreach (var g in recentGamesResponse.RecentlyPlayedGames.games)
                {
                    recentGames.Add(new DataAccess.Models.ProfileRecentGame()
                    {
                        AppId = g.appid,
                        SteamId = steamId
                    });
                }

                //db.ProfileRecentGames.AddRange(recentGames);
                //db.ProfileRecentGames.Bulk
                db.BulkInsert<DataAccess.Models.ProfileRecentGame>(recentGames);
            }



        }


        private DataAccess.Models.PlayerProfile AddProfile(SteamApiWrapper.Models.PlayerSummaries.Player p)
        {
            DataAccess.Models.PlayerProfile profile = new DataAccess.Models.PlayerProfile();

            //profile = Converters.ServiceToModel.PlayerProfile.Convert(profile, p) as DataAccess.Models.PlayerProfile;
            profile.ConvertService(p);

            profile.LastUpdate = DateTime.Now;
            profile.LibraryLastUpdate = new DateTime(2000, 1, 1);

            //List<DataAccess.Models.ProfileRecentGame> rgList = SetRecentGames(p.steamID64, p.mostPlayedGames);

            db.PlayerProfiles.Add(profile);
            //db.ProfileRecentGames.AddRange(rgList);
            return profile;
        }

        private void UpdateProfile(DataAccess.Models.PlayerProfile p, SteamApiWrapper.Models.PlayerSummaries.Player pr)
        {
            p.ConvertService(pr);
        }





        private void InsertUpdateGames(long steamId, SteamApiWrapper.Models.OwnedGames.Response gl)
        {
            var userGames = db.PlayerGames.Where(x => x.SteamId == steamId).ToList();

            var gameIds = gl.games.Select(x => (long)x.appid).ToList();
            var gameSchemas = db.GameSchemas.Where(x => gameIds.Contains(x.AppId)).Select(x => x.AppId);

            var bulkInsertGames = new List<DataAccess.Models.PlayerGame>();
            var bulkInsertSchemas = new List<DataAccess.Models.GameSchema>();
            foreach (var g in gl.games)
            {
                var existingG = userGames.Where(x => x.AppID == g.appid).FirstOrDefault();

                if (existingG == null)
                {
                    existingG = new DataAccess.Models.PlayerGame();

                    //db.PlayerGames.Add(existingG);
                    bulkInsertGames.Add(existingG);

                    existingG.Playtime_Forever = 0;
                    existingG.AchievementRefresh = new DateTime(2000, 1, 1);
                    existingG.TotalAchievements = 0;
                    existingG.AchievementsLocked = 0;
                    existingG.AchievementsEarned = 0;
                    //existingG.has_achievements = g.has_community_visible_stats;
                }


                existingG.LastUpdated = DateTime.Now;
                existingG.RefreshAchievements = (g.playtime_forever != existingG.Playtime_Forever);

                existingG.ConvertService(g, steamId);

                existingG.LastUpdated = DateTime.Now;


                //Add Schema if it's not there
                if (gameSchemas.Contains(g.appid) == false)
                {
                    bulkInsertSchemas.Add(new DataAccess.Models.GameSchema()
                    {
                        AppId = g.appid,
                        HasAchievements = g.has_community_visible_stats,
                        has_community_visible_stats = g.has_community_visible_stats,
                        Img_Icon_Url = (string.IsNullOrEmpty(g.img_icon_url)) ? "Not Found" : g.img_icon_url,
                        Img_Logo_Url = (string.IsNullOrEmpty(g.img_logo_url)) ? "Not Found" : g.img_logo_url,
                        Name = g.name,
                        LastSchemaUpdate = new DateTime(2000, 1, 1)
                    });
                }
            }
            try
            {
                if (bulkInsertSchemas.Count > 0)
                {
                    db.BulkInsert<DataAccess.Models.GameSchema>(bulkInsertSchemas);
                }

                if (bulkInsertGames.Count > 0)
                {
                    db.BulkInsert<DataAccess.Models.PlayerGame>(bulkInsertGames);
                }


                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }


        }
    }
}
