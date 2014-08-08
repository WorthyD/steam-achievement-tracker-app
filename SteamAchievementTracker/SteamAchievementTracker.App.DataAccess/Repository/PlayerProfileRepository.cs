using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Repository {
    public class PlayerProfileRepository {
        public Data.PlayerProfile _db;
        public PlayerProfileRepository() {
            _db = new Data.PlayerProfile(); 
        }

        public async Task<Model.Profile> GetPlayerDetails(string SteamID) {
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = SteamID;
            var response = await request.GetResponse();
            
            return  new Model.Profile( response.Profile);
        }


        public async Task<Model.Profile> GetProfileFromDB(ulong steam64ID) {
            var player = _db.GetItem(steam64ID);
            return player;
        }

        public async Task<Model.Profile> GetProfileCached(ulong steam64ID,string steamID) {
            var player = _db.GetItem(steam64ID);

            if (player == null) {
                player = await GetPlayerDetails(steamID);

                _db.InsertItem(player);
            }

            return player;
        }

    }
}
