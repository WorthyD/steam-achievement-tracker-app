using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData.Model
{
    public class GameStat : IGameAchievement
    {
       public string StatsURL { get; set; }
       public string AchievementID { get; set; }
       public bool IsUnlocked { get; set; }
       public string AchievementIcon { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public string UnlockTimestamp { get; set; }

       public GameStat()
       {
           this.PopulateDesignData("Test", new Random());
       }
       public void PopulateDesignData(string name, Random rnd)
       {
           int ticks = rnd.Next(0, 100);
           this.StatsURL = "http://google.com";
           this.AchievementID = name;
           this.IsUnlocked = (ticks % 2 == 0);
           this.AchievementIcon = (this.IsUnlocked) ? "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/72850/07a5ef16690568be4686a8c0d3ba5b031acde580.jpg" : "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/72850/24f77c69c58ff5cdf6ff574796f2c7ed69ba9e46.jpg";
           this.Name = name;
           this.Description = name + "Desc";
           this.UnlockTimestamp = DateTime.Now.Ticks.ToString();

       }
    }
}
