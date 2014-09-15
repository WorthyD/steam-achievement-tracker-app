using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Model
{
    public class RecentGame : IRecentGame
    {
        public long ID64
        {
            get;
            set;
        }


        public string GameLink
        {
            get;
            set;
        }
    }
}
