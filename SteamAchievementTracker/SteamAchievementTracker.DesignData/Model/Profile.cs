using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData.Model
{
    public  class Profile : IProfile
    {
        public long ID64
        {
            get;
            set;
        }

        public string ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ThumbURL
        {
            get;
            set;
        }

        public List<IGame> RecentGames
        {
            get;
            set;
        }

        public Profile()
        {
            this.Name = "Daniel Worthy";
            this.ThumbURL = "http://www.gravatar.com/avatar/67b727175a880f13e6240c856764670e.png?s=50";
            var count = 10;
            this.RecentGames = new List<IGame>();
            for (var i = 0; i < count; i++)
            {
                Game g = new Game();
                g.PopulateDesignData("Game" + i);
                this.RecentGames.Add(g);
            }
        }
    }
}
