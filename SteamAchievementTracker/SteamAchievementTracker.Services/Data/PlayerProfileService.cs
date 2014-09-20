using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Services.Data
{
    public class PlayerProfileService : IPlayerProfileService
    {
        public SteamAchievementTracker.App.DataAccess.Data.PlayerProfile _db;
        public SteamAchievementTracker.App.DataAccess.Data.PlayerRecentGames _recentDB;

        public string DBName = "SteamAchievementTracker.db";
        public PlayerProfileService()
        {
            _db = new SteamAchievementTracker.App.DataAccess.Data.PlayerProfile(DBName);
            _recentDB = new App.DataAccess.Data.PlayerRecentGames();
            _recentDB.connectionString = DBName;
        }

        public async Task<IProfile> GetFreshPlayerDetails(string SteamID, bool update)
        {
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = SteamID;
            var response = await request.GetResponse();

            var model = new Model.Profile(response.Profile);
            if (update)
            {
                model.LastUpdate = DateTime.Now;
                _db.UpdateItem(model.ID64, model);
            }
            else
            {
                _db.InsertItem(model);
            }

            _recentDB.InsertAllForUser(model.ID64, model.RecentGameLinks);
            return model;
        }


        public IProfile GetProfileFromDB(long steam64ID)
        {
            var player = _db.GetItem(steam64ID);
            if (player != null)
            {
                var recentGameLinks = _recentDB.GetByUserID(steam64ID);
                player.RecentGameLinks = recentGameLinks.Select(x => x.GameLink).ToList();
            }
            return player;
        }

        public async Task<IProfile> GetProfileCached(long steam64ID, string steamID)
        {
            IProfile player = this.GetProfileFromDB(steam64ID);
            

            if ((player == null) || player.LastUpdate < DateTime.Now.AddMinutes(-Settings.Profile.ProfileRefreshInterval)){
            //if ((player == null) || player.LastUpdate < DateTime.Now.AddMinutes(0)){
                player = await GetFreshPlayerDetails(steamID, (player != null));
            }

            return player;
        }




    }
}
