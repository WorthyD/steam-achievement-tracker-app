using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData.Services
{
    public class PlayerStatsService : IPlayerStatsService
    {
        public List<Contracts.Model.IGameAchievement> GetGameAchievementsCached(string statURL)
        {
            return GetStats();
        }

        public Contracts.Model.IGameAchievement GetGameAchievementCached(string statURL, string apiName)
        {
            throw new NotImplementedException();
        }
        public List<Contracts.Model.IGameAchievement> GetStats()
        {
            int count = 40;

            List<Contracts.Model.IGameAchievement> ga = new List<Contracts.Model.IGameAchievement>();
            var rnd = new Random();
            for (var i = 0; i < count; i++)
            {
                Model.GameStat g = new Model.GameStat();
                g.PopulateDesignData("Game" + i, rnd);
                ga.Add(g);
            }
            return ga;
        }
        public async Task<List<IGameAchievement>> GetFreshStats(string statURL)
        {
            return GetStats();
        }




        public Task UpdateStatsByList(List<IGame> statUrls, IProgress<string> progress, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<List<IGameAchievement>> GetGameStatistics(IGame game, bool delay = false)
        {
            throw new NotImplementedException();
        }
    }
}
