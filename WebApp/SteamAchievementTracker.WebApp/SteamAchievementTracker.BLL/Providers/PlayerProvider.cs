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
            request.SteamID = steamId;
            var response = await request.GetResponse();
            if (response == null || response.Profile == null) {
                //Throw new exception
            }


            using (var db = new DataAccess.ModelContext()) {
                var dbProfile = db.PlayerProfiles.Where(x => x.PlayerID64 == response.Profile.steamID64).FirstOrDefault();

                if (dbProfile == null) {
                    //Add profile
                    //Add library
                    //Add recent games.
                } else if (dbProfile.LastUpdate < Settings.ProfileExpiration) {
                    //Update profile & recent games
                }


            }

            return profile;
        }
    }
}
