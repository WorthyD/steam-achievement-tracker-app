using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.WebApi.ViewModels
{
    public class GameAchievement 
    {
        public long AppId { get; set; }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Hidden { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Percent { get; set; }

        public bool Achieved { get; set; }
        public DateTime? UnlockTimestamp { get; set; }

       
        public GameAchievement(IPlayerGameAchievement pga, IGameAchievement ga)
        {
            this.AppId = ga.AppId;
            this.Name = ga.Name;
            this.DisplayName = ga.DisplayName;
            this.Hidden = ga.Hidden;
            this.Icon = (pga.Achieved)? ga.Icon : ga.IconGray;
            this.Description = ga.Description;
            ///this.IconGray = ga.IconGray;
            this.Percent = (int)ga.Percent;

            this.Achieved = pga.Achieved;
            this.UnlockTimestamp = pga.UnlockTimestamp;
        }


    }
}
