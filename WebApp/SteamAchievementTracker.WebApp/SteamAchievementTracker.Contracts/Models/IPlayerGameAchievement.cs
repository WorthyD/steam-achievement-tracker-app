using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Models {
    public interface IPlayerGameAchievement {
        long PlayerID64 { get; set; }
        int AppID { get; set; }
        string AchievementID { get; set; }
        string StatsURL { get; set; }
        bool IsUnlocked { get; set; }
        string AchievementIcon { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string UnlockTimestamp { get; set; }
    }
}
