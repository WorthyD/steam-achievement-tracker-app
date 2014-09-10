using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData.Model
{
    public class PlayerLibrary : IPlayerLibrary
    {
        public List<IGame> GameList { get; set; }

        public PlayerLibrary() {
            var count = 10;
            this.GameList = new List<IGame>();
            var rnd = new Random();
            for (var i = 0; i < count; i++)
            {
                Game g = new Game();
                g.PopulateDesignData("Game" + i, rnd);
                this.GameList.Add(g);
            }
        }
    }
}
