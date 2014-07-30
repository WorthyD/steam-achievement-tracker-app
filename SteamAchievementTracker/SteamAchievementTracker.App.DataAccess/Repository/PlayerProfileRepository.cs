using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Repository {
    public class PlayerProfileRepository {
        public async Task<Model.Profile> GetPlayerDetails(string SteamID) {
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = SteamID;
            var response = await request.GetResponse();
            
            return  new Model.Profile( response.Profile);
        }

    }
}
