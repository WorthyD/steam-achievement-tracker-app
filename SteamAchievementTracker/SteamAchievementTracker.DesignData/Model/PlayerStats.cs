using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData.Model
{
    public class PlayerStats : IStatistics
    {
        public int LibraryCount
        {
            get;
            set;
        }

        public int AchievementCount
        {
            get;
            set;
        }

        public int UnlockedAchievementCount
        {
            get;
            set;
        }

        public int TotalPlayTime
        {
            get;
            set;
        }
        public int PerfectGames { get; set; }
    }
}
