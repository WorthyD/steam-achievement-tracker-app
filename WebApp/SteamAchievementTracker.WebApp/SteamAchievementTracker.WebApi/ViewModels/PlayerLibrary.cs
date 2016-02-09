using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.WebApi.ViewModels
{
    public class PlayerLibrary
    {
        public List<GameDetails> Library { get; set; }

        public PlayerLibrary(IList<IPlayerGame> pg)
        {
            this.Library = new List<GameDetails>();
            foreach (var p in pg)
            {
                this.Library.Add(new GameDetails(p));
            }
        }


    }
}
