using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Providers {
    public interface IPlayerAchievementServices {
        List<IPlayerGameAchievement> GetGameAchievementsCached(string statURL);
        IPlayerGameAchievement GetGameAchievementCached(string statURL, string apiName);
        Task<List<IPlayerGameAchievement>> GetFreshStats(string statURL);
        //Task UpdateStatsByList(List<IGame> statUrls, IProgress<int> progress, CancellationToken ct);
        Task<List<IPlayerGameAchievement>> GetGameStatistics(IPlayerGame game, bool delay = false);
    }
}
