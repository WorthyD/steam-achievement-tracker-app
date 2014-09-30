using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Services
{
    public interface IPlayerStatsService
    {
        List<IGameAchievement> GetGameAchievementsCached(string statURL);
        IGameAchievement GetGameAchievementCached(string statURL, string apiName);
        Task<List<IGameAchievement>> GetFreshStats(string statURL);
        Task UpdateStatsByList(List<string> statUrls, IProgress<string> progress);
    }
}
