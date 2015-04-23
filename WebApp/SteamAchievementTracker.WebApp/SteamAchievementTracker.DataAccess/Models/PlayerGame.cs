using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DataAccess.Models {
    public class PlayerGame {

        public long PlayerID64 { get; set; }
        public int AppID { get; set; }



        public string Name { get; set; }
        public string StatsLink { get; set; }
        public string GameLink { get; set; }
        public string Logo { get; set; }
        public string Icon { get; set; }
        public decimal HoursPlayed { get; set; }
        public decimal RecentHours { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime AchievementRefresh { get; set; }

        public bool RefreshAchievements { get; set; }
        public int AchievementsEarned { get; set; }
        public int AchievementsLocked { get; }
        public int TotalAchievements { get; set; }

        public bool HasAchievements { get; set; }



        public bool BeenProcessed { get; }
        public double PercentComplete { get; }


    }
}
