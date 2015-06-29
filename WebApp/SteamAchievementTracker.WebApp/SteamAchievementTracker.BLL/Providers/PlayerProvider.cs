using SteamAchievementTracker.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL.Providers {
    public class PlayerProvider : IPlayerProfileService {

        public PlayerProvider() {
            //TODO: _pRepo == data access repo
        }


        public async Task<Contracts.Models.IPlayerProfile> GetProfileFromLogin(string steamId) {
            DataAccess.Models.PlayerProfile profile = new DataAccess.Models.PlayerProfile();
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            SteamAPI.Player.PlayerGamesRequest gRequest = new SteamAPI.Player.PlayerGamesRequest();
            request.SteamID = steamId;
            var response = await request.GetResponse();
            if (response == null || response.Profile == null) {
                //Throw new exception
            }




            using (var db = new DataAccess.ModelContext()) {
                var dbProfile = db.PlayerProfiles.Where(x => x.PlayerID64 == response.Profile.steamID64).FirstOrDefault();


                if (dbProfile == null) {
                dbProfile =   AddProfile(db, response.Profile);
                } else if (dbProfile.LastUpdate < Settings.ProfileExpiration) {
                    UpdateProfile(db, dbProfile, response.Profile);
                }


                gRequest.SteamID = steamId;
                var gResponse = await gRequest.GetResponse();


                if (dbProfile.LibraryLastUpdate < Settings.ProfileExpiration) {

                }


            }

            return profile;
        }


        public DataAccess.Models.PlayerProfile AddProfile(DataAccess.ModelContext db, SteamAPI.Models.Profile.profile p) {
            DataAccess.Models.PlayerProfile profile = new DataAccess.Models.PlayerProfile();
            profile.PlayerID64 = p.steamID64;
            profile.CustomUrl = p.customURL;
            profile.LastUpdate = DateTime.Now;
            profile.LibraryLastUpdate = DateTime.MinValue;
            profile.Name = p.realname;
            profile.ThumbURL = p.avatarFull;


            List<DataAccess.Models.ProfileRecentGame> rgList = SetRecentGames(p.steamID64, p.mostPlayedGames);
            
            db.PlayerProfiles.Add(profile);
            db.ProfileRecentGames.AddRange(rgList);
            return profile;
        }
        public void UpdateProfile(DataAccess.ModelContext db, DataAccess.Models.PlayerProfile p, SteamAPI.Models.Profile.profile pr) {
            p.CustomUrl = pr.customURL;
            p.LastUpdate = DateTime.Now;
            p.Name = pr.realname;
            p.ThumbURL = pr.avatarFull;

            var recentGames = db.ProfileRecentGames.Where(x => x.ID64 == p.PlayerID64);
            db.ProfileRecentGames.RemoveRange(recentGames);
            List<DataAccess.Models.ProfileRecentGame> rgList = SetRecentGames(p.PlayerID64, pr.mostPlayedGames);
            
            db.ProfileRecentGames.AddRange(rgList);

        }



        public List<DataAccess.Models.ProfileRecentGame> SetRecentGames( long id, SteamAPI.Models.Profile.profileMostPlayedGame[] games) {
            List<DataAccess.Models.ProfileRecentGame> rgList = new List<DataAccess.Models.ProfileRecentGame>();
            foreach (var i in games) {
                DataAccess.Models.ProfileRecentGame rg = new DataAccess.Models.ProfileRecentGame();
                int appId = 0;
                if (int.TryParse(i.statsName, out appId)) {
                    rg.AppID = appId;
                    rg.ID64 = id;
                    rgList.Add(rg);
                }
            }
            return rgList;
        }

        public void InsertUpdateGames(DataAccess.ModelContext db,long userId64,  SteamAPI.Models.gamesList gl) {
            var userGames = db.PlayerGames.Where(x => x.PlayerID64 == userId64).ToList();

            foreach (var g in gl.games) {
                var existingG = userGames.Where(x => x.AppID == g.appID).FirstOrDefault();

                if (existingG == null) {
                    existingG = new DataAccess.Models.PlayerGame();

                    db.PlayerGames.Add(existingG);

                    existingG.BeenProcessed = false;
                    //existingG.HasAchievements = (!string.IsNullOrEmpty(tGame.StatsLink));

                }



            }

        }
    }
}
