using SteamAchievementTracker.BLL.Converters.ServiceToModel;
using SteamAchievementTracker.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL.Providers
{
    public class PlayerProvider : BaseProvider, IPlayerProfileService
    {

        public PlayerProvider()
        {
            //TODO: _pRepo == data access repo
        }


        public async Task<Contracts.Models.IPlayerProfile> GetProfileFromLogin(long steamId)
        {
            DataAccess.Models.PlayerProfile profile = new DataAccess.Models.PlayerProfile();


            var request = new SteamApiWrapper.SteamUser.GetPlayerSummariesRequest(base.APIKey);
            var gRequest = new SteamApiWrapper.PlayerService.GetOwnedGamesRequest(base.APIKey);



            //SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            //SteamAPI.Player.PlayerGamesRequest gRequest = new SteamAPI.Player.PlayerGamesRequest();



            request.ProfileIds = new List<long>();
            request.ProfileIds.Add(steamId);

            var response = await request.GetResponse();
            if (response == null || response.Players == null)
            {
                //Throw new exception
            }

            var player = response.Players.FirstOrDefault();



            using (var db = new DataAccess.ModelContext())
            {
                var dbProfile = db.PlayerProfiles.Where(x => x.SteamId == steamId).FirstOrDefault();


                if (dbProfile == null)
                {
                    dbProfile = AddProfile(db, player);
                }
                else if (dbProfile.LastUpdate < Settings.ProfileExpiration)
                {
                    dbProfile.ConvertService(player);
                }


                gRequest.SteamId = steamId;
                var gResponse = await gRequest.GetResponse();

                if (dbProfile.LibraryLastUpdate < Settings.ProfileExpiration)
                {
                    InsertUpdateGames(db, steamId, gResponse.OwnedGames);
                }


            }

            return profile;
        }


        private DataAccess.Models.PlayerProfile AddProfile(DataAccess.ModelContext db, SteamApiWrapper.Models.PlayerSummaries.Player p)
        {
            DataAccess.Models.PlayerProfile profile = new DataAccess.Models.PlayerProfile();

            //profile = Converters.ServiceToModel.PlayerProfile.Convert(profile, p) as DataAccess.Models.PlayerProfile;
            profile.ConvertService(p);

            profile.LastUpdate = DateTime.Now;
            profile.LibraryLastUpdate = DateTime.MinValue;

            //List<DataAccess.Models.ProfileRecentGame> rgList = SetRecentGames(p.steamID64, p.mostPlayedGames);

            db.PlayerProfiles.Add(profile);
            //db.ProfileRecentGames.AddRange(rgList);
            return profile;
        }
        private void UpdateProfile(DataAccess.ModelContext db, DataAccess.Models.PlayerProfile p, SteamApiWrapper.Models.PlayerSummaries.Player  pr)
        {
            p.ConvertService(pr);
        }



        //private List<DataAccess.Models.ProfileRecentGame> SetRecentGames(long id, SteamAPI.Models.Profile.profileMostPlayedGame[] games)
        //{
        //    List<DataAccess.Models.ProfileRecentGame> rgList = new List<DataAccess.Models.ProfileRecentGame>();
        //    foreach (var i in games)
        //    {
        //        DataAccess.Models.ProfileRecentGame rg = new DataAccess.Models.ProfileRecentGame();
        //        int appId = 0;
        //        if (int.TryParse(i.statsName, out appId))
        //        {
        //            rg.AppID = appId;
        //            rg.ID64 = id;
        //            rgList.Add(rg);
        //        }
        //    }
        //    return rgList;
        //}

        private void InsertUpdateGames(DataAccess.ModelContext db, long steamId, SteamApiWrapper.Models.OwnedGames.Response gl)
        {
            var userGames = db.PlayerGames.Where(x => x.SteamId == steamId).ToList();

            foreach (var g in gl.games)
            {
                var existingG = userGames.Where(x => x.AppID == g.appid).FirstOrDefault();

                if (existingG == null)
                {
                    existingG = new DataAccess.Models.PlayerGame();

                    db.PlayerGames.Add(existingG);

                    existingG.BeenProcessed = false;
                }

                existingG.ConvertService(g, steamId);
            }
            db.SaveChanges();

        }
    }
}
