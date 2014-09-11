using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Model
{
    public interface IGame
    {
        long SteamUserID { get; set; }
        int AppID { get; set; }
        string Name { get; set; }
        string StatsLink { get; set; }
        string GameLink { get; set; }
        string Logo { get; set; }
        decimal HoursPlayed { get; set; }
        decimal RecentHours { get; set; }
        DateTime LastUpdated { get; set; }
        DateTime AchievementRefresh { get; set; }

        int AchievementsEarned { get; set; }
        int TotalAchievements { get; set; }
       
    }
}
