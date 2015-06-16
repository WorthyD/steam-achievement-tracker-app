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
        

        public async Task<Contracts.Models.IPlayerProfile> GetProfile(string steamId) {
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
                   AddProfile(db, response.Profile);
                } else if (dbProfile.LastUpdate < Settings.ProfileExpiration) {
                    //Update profile & recent games
                }


                    gRequest.SteamID = steamId;
                    var gResponse = await gRequest.GetResponse();
 

            }

            return profile;
        }


        public void AddProfile(DataAccess.ModelContext db, SteamAPI.Models.Profile.profile p) {
            DataAccess.Models.PlayerProfile profile = new DataAccess.Models.PlayerProfile();
            profile.CustomUrl = p.customURL;
            profile.LastUpdate = DateTime.Now;
            profile.Name = p.realname;
            profile.ThumbURL = p.avatarFull;

           
        }
        public void UpdateProfile(DataAccess.Models.PlayerProfile p) {
            //p.

        }
        public void SetRecentGames() {

        }

        public void GetGames(DataAccess.ModelContext db) {

        }
    }
}
