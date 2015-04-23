using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DataAccess.Models {
    public class PlayerGameAchievements {

        public long PlayerID64 { get; set; }

        public string StatsURL { get; set; }
        public string AchievementID { get; set; }
        public bool IsUnlocked { get; set; }
        public string AchievementIcon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UnlockTimestamp { get; set; }
    }
}
