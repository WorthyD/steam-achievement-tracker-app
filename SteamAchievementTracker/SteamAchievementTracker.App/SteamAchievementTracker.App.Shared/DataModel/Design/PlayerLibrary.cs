using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.DataModel {
    public partial class PlayerLibrary {
        public void PopulateDesignData() {
            var count = 10;
            this.GameList = new List<Game>();
            for (var i = 0; i < count; i++) {
                Game g = new Game();
                g.PopulateDesignData("Game" + i);
                this.GameList.Add(g);
            }
        }
    }
}
