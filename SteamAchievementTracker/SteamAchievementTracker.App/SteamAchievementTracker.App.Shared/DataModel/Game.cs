using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.DataModel {
    public partial class Game {
        public uint AppID { get; set; }
        public string Name { get; set; }
        public string StatsLink { get; set; }
        public string Logo { get; set; }
        public decimal HoursPlayed { get; set; }
        public decimal HoursOnRecord { get; set; }

        public int AchievementsEarned { get; set; }
        public int TotalAchievements { get; set; }
        public decimal PercentComplete { get {
            return AchievementsEarned / TotalAchievements;
        } }

        public string ProgressText {
            get {
                return string.Format("{0} of {1}", AchievementsEarned, TotalAchievements);
            }
        }
    }
}
