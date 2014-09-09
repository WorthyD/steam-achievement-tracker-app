using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Model
{
  public   interface IGameAchievement
    {
        string StatsURL { get; set; }
        string AchievementID { get; set; }
        bool IsUnlocked { get; set; }
        string AchievementIcon { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string UnlockTimestamp { get; set; }

    }
}
