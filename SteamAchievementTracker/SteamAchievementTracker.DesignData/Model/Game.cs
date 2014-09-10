using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData.Model
{
   public  class Game: IGame
    {
        public long SteamUserID
        {
           get;set;
          
        }

        public int AppID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string StatsLink
        {
            get;
            set;
        }

        public string GameLink
        {
            get;
            set;
        }

        public string Logo
        {
            get;
            set;
        }

        public decimal HoursPlayed
        {
            get;
            set;
        }

        public decimal RecentHours
        {
            get;
            set;
        }

        public DateTime LastUpdated
        {
            get;
            set;
        }

        public DateTime AchievementRefresh
        {
            get;
            set;
        }

        public int AchievementsEarned
        {
            get;
            set;
        }

        public int TotalAchievements
        {
            get;
            set;
        }

        public decimal PercentComplete
        {
            get
            {
                return AchievementsEarned / TotalAchievements;
            }
        }

        public string ProgressText
        {
            get
            {
                return string.Format("{0} of {1}", AchievementsEarned, TotalAchievements);
            }
        }


        public void PopulateDesignData(string name)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(0, 100);
            this.Name = name;
            this.Logo = GetRandomImage();
            this.RecentHours = ticks;

            this.AchievementsEarned = ticks;
            this.TotalAchievements = 100;

        }

        private string GetRandomImage()
        {
            List<string> logos = new List<string>() { 
            "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/277430/5b8a0774b816b0edeaac1cbf2deeaec26dd486a8.jpg",
            "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/246420/4a30b9d0a8b6e7287f2b617dd28dce6910aeafe8.jpg",
            "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/285160/4e0add73085939dff818bdc506437560feacfd91.jpg",
            "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/234710/0b274bb5ade23104ce267a05ce7ac0f7aaa0248d.jpg",
         "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/78000/7c4e103ce278e3bc50d7e7b33c4ddb8196f88817.jpg",
         "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/107100/d113d66ef88069d7d35a74cfaf2e2ee917f61133.jpg",
         "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/218620/4467a70648f49a6b309b41b81b4531f9a20ed99d.jpg",
         "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/247370/38b18142083a48c59041480b0ee86888423146f8.jpg",
         "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/247370/38b18142083a48c59041480b0ee86888423146f8.jpg",
         "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/215710/a40127479fd3fe50fe9fbf7ff014c7ad3ce20df5.jpg",
         "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/204360/793216ec14c639bdaf2f0119c8cc408b8e9ad7b1.jpg"
            };

            return logos.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

        }
    }
}
