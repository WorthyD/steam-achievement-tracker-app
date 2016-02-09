using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.WebApi.ViewModels
{
    public class GameAchievement : IPlayerGameAchievement, IGameAchievement
    {
        public long AppId { get; set; }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Hidden { get; set; }
        public string Icon { get; set; }
        public string IconGray { get; set; }
        public double Percent { get; set; }

        public long SteamId { get; set; }
        public long AppID { get; set; }
        public string ApiName { get; set; }
        public bool Achieved { get; set; }
        public DateTime UnlockTimestamp { get; set; }

        public GameAchievement(IPlayerGameAchievement pga, IGameAchievement ga)
        {
            this.AppId = ga.AppId;
            this.Name = ga.Name;
            this.DisplayName = ga.DisplayName;
            this.Hidden = ga.Hidden;
            this.Icon = ga.Icon;
            this.IconGray = ga.IconGray;
            this.Percent = ga.Percent;

            this.SteamId = pga.SteamId;
            this.AppID = pga.AppID;
            this.ApiName = pga.ApiName;
            this.Achieved = pga.Achieved;
            this.UnlockTimestamp = pga.UnlockTimestamp;
        }


    }
}
