using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Services.Data
{
    public class PlayerProfileService:  IPlayerProfileService
    {
        public SteamAchievementTracker.App.DataAccess.Data.PlayerProfile _db;
        public string DBName = "SteamAchievementTracker.db";
           public PlayerProfileService(){
        //   {
        //    _db = new Data.PlayerProfile(connection); 
               _db = new  SteamAchievementTracker.App.DataAccess.Data.PlayerProfile(DBName);
        }

        public async Task<IProfile> GetPlayerDetails(string SteamID)
        {
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
