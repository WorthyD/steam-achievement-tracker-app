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

                /*
                var request = new SteamApiWrapper.SteamUser.GetPlayerSummariesRequest(base.APIKey);
                var rgRequest = new SteamApiWrapper.PlayerService.GetRecentlyPlayedGamesRequest(base.APIKey);

                request.ProfileIds = new List<long>();
                request.ProfileIds.Add(steamId);

                rgRequest.SteamId = steamId;

                var profileResponse = request.GetResponse();
                var recentGamesResponse = rgRequest.GetResponse();

                await Task.WhenAll(profileResponse, recentGamesResponse);

                var response = await profileResponse;
                var recentGames = await recentGamesResponse;


                if (response == null || response.Players == null)
                {
                    //Throw new exception
                    return null;
                }


                var player = response.Players.FirstOrDefault();
    
                var profileTask = ProcessProfile( profile,  player);


                await Task.WhenAll(profileTask, recentGamesResponse);

                db.SaveChanges();
                */

                var profileTask = ProcessProfile(steamId, profile);
                var recentGameTask = ProcessRecentGames(steamId);
                await Task.WhenAll(profileTask, recentGameTask);

                profile = await profileTask;

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

            var bulkInsertGames = new List<DataAccess.Models.PlayerGame>();
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
                }


                existingG.LastUpdated = DateTime.Now;
                existingG.RefreshAchievements = (g.playtime_forever != existingG.Playtime_Forever);

                existingG.ConvertService(g, steamId);

                existingG.LastUpdated = DateTime.Now;
            }
            try
            {

                if (bulkInsertGames.Count > 0) {
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
