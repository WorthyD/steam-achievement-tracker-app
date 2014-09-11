using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.DesignData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData.Services
{
    public class PlayerLibraryService: IPlayerLibraryService
    {
        public async Task<List<Contracts.Model.IGame>> GetPlayerRecentlyPlayedGames(long steamID64, string steamID)
        {
            return GetGames();
        }

        public async Task<List<Contracts.Model.IGame>> GetPlayerLibraryCached(long steamID64)
        {
            return GetGames();
        }

        public  async Task<List<Contracts.Model.IGame>> GetPlayerLibraryRefresh(long steamID64, string steamID)
        {
            return GetGames();
        }

        public  async void UpdateGameStats(string statsUrl, int achievementsEarned, int totalAchievements)
        {
        }
        public List<IGame> GetGames()
        {
            var count = 15;
            var GameList = new List<IGame>();

            var rnd = new Random();
            for (var i = 0; i < count; i++)
            {
                Game g = new Game();
                g.PopulateDesignData("Game" + i, rnd);
                GameList.Add(g);
            }
            return GameList;

        }
    }
}
