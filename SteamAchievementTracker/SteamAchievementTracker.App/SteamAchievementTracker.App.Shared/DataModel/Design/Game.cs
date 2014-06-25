using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.DataModel{
    public partial class Game {

        public void PopulateDesignData(string name) {
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(0, 100);
            this.Name = name;
            this.Logo = "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/277430/5b8a0774b816b0edeaac1cbf2deeaec26dd486a8.jpg";
            this.HoursOnRecord = ticks;

            this.AchievementsEarned = ticks;
            this.TotalAchievements = 100;
           
        }
    }
}
