using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.DataModel {
    public partial class PlayerProfile {
        public void PopulateDesignData() {
            this.Name = "Daniel Worthy";
            this.ThumbURL = "http://www.gravatar.com/avatar/67b727175a880f13e6240c856764670e.png?s=50";
            var count = 10;
            this.RecentGames = new List<Game>();
            for (var i = 0; i < count; i++) {
                Game g = new Game();
                g.PopulateDesignData("Game" + i);
                this.RecentGames.Add(g);
            }
            
        }

    }
}
