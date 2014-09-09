using SteamAchievementTracker.Contracts.Model;
using SteamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Model
{
    public class GameAchievement : IGameAchievement
    {
        public string StatsURL { get; set; }

        public string AchievementID { get; set; }
        public bool IsUnlocked { get; set; }
        public string AchievementIcon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UnlockTimestamp { get; set; }


        //playerstatsAchievement
        public GameAchievement()
        {
            this.StatsURL = string.Empty;
            this.AchievementID = string.Empty;
            this.IsUnlocked = false;
            this.AchievementIcon = string.Empty;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.UnlockTimestamp = "0";
        }

        public GameAchievement(playerstatsAchievement psa, string statURL)
        {
            this.StatsURL = statURL;
            this.AchievementID = psa.apiname;
            this.IsUnlocked = psa.closed;
            this.AchievementIcon = (psa.closed) ? psa.iconClosed : psa.iconOpen;
            this.Name = psa.name;
            this.Description = psa.description;
            this.UnlockTimestamp = (psa.unlockTimestampSpecified) ? psa.unlockTimestamp.ToString() : string.Empty;
        }

    }
}
