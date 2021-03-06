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
    public class PlayerLibraryService : IPlayerLibraryService
    {
        public async Task<List<Contracts.Model.IGame>> GetPlayerRecentlyPlayedGames(long steamID64, string steamID)
        {
            return GetGames();
        }

        public async Task<List<Contracts.Model.IGame>> GetPlayerLibraryCached(long steamID64)
        {
            return GetGames();
        }

        public async Task<List<Contracts.Model.IGame>> GetPlayerLibraryRefresh(long steamID64, string steamID)
        {
            return GetGames();
        }

        public async void UpdateGameStats(string statsUrl, int achievementsEarned, int totalAchievements)
        {
        }
        public List<IGame> GetGames()
        {
            var count = 5;
            var GameList = new List<IGame>();

            var rnd = new Random();
            for (var i = 0; i < count; i++)
            {
                GameList.Add(DummyClasses.Game.GetRandomGame("Game" + i, rnd));
            }
            return GameList;

        }

        public List<IGame> GetPlayerRecentlyPlayedGames(long steamID64, List<string> gameLinks)
        {
            return GetGames();
        }


        public IGame GetGameByID(long appID, long userId)
        {
            return GetGames().FirstOrDefault();
        }


        public IStatistics GetPlayerStats(long steamID64)
        {
            return new Model.PlayerStats()
            {
                AchievementCount = 100,
                LibraryCount = 100,
                TotalPlayTime = 100,
                UnlockedAchievementCount = 100,
                PerfectGames = 100
            };
        }


        public void UpdateGameStats(string statsUrl, string gameIcon, int achievementsEarned, int totalAchievements) {
           // throw new NotImplementedException();
        }
    }
}
