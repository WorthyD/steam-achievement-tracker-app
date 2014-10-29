using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Model
{
    public interface IStatistics
    {
        int LibraryCount { get; set; }
        int LibraryAchievementCount { get; set; }
        int AchievementCount { get; set; }
        int PerfectGames { get; set; }
        int UnlockedAchievementCount { get; set; }
        int TotalPlayTime { get; set; }
    }
}
