using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Model {
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
