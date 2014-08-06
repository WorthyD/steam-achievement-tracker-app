using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Repository {
    public class PlayerStatsRepository {
        public async Task<SteamAPI.Models.playerstats> GetPlayerStats(string statURL) {
            SteamAPI.Player.PlayerGameStatsRequest request = new SteamAPI.Player.PlayerGameStatsRequest();
            request.GameUrl = statURL;
            var response = await request.GetResponse();

            return response.PlayerStats;
        }

        public async Task<List<Model.GameAchievement>> GetGameAchievementsCached(string statURL) {
            return null;
        }
    }
}
