using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Services.Data
{
    public class PlayerProfileService
    {
        public SteamAchievementTracker.App.DataAccess.Data.PlayerProfile _db;
        //   public PlayerProfileService(string connection)
        //   {
        //    _db = new Data.PlayerProfile(connection); 
        //}

        public async Task<Model.Profile> GetPlayerDetails(string SteamID) {
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = SteamID;
            var response = await request.GetResponse();
            
            return  new Model.Profile( response.Profile);
        }


        public async Task<IProfile> GetProfileFromDB(long steam64ID) {
            var player = _db.GetItem(steam64ID);
            return player;
        }

        public async Task<IProfile> GetProfileCached(long steam64ID, string steamID)
        {
            var player = _db.GetItem(steam64ID);

            if (player == null) {
                player = await GetPlayerDetails(steamID);

                _db.InsertItem(player);
            }

            return player;
        }

    }
}
