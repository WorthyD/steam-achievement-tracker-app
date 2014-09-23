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
        public List<string> RecentGameLinks { get; set; }
        public DateTime LastUpdate { get; set; }
        public Profile()
        {
            this.Name = "Daniel Worthy";
            this.ThumbURL = "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/avatars/22/22053d6c2f15587db897d259035f7b395ead2155_full.jpg";
            var count = 10;
            this.RecentGames = new List<IGame>();
            var rnd = new Random();
            this.RecentGameLinks = new List<string>();
            for (var i = 0; i < count; i++)
            {
                Game g = new Game();
                g.PopulateDesignData("Game" + i, rnd);
                this.RecentGames.Add(g);
                this.RecentGameLinks.Add(g.GameLink);
            }

            
        }
    }
}
