using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.Contracts.Model;
using SteamAPI.Models;



namespace SteamAchievementTracker.Model
{
    public class Game : IGame
    {
        public long SteamUserID { get; set; }
        public int AppID { get; set; }
        public string Name { get; set; }
        public string StatsLink { get; set; }
        public string GameLink { get; set; }
        public string Logo { get; set; }
        public decimal HoursPlayed { get; set; }
        public decimal RecentHours { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime AchievementRefresh { get; set; }

        public int AchievementsEarned { get; set; }
        public int TotalAchievements { get; set; }
        public double PercentComplete
        {
            get
            {
                if (TotalAchievements == 0) return 0;
                var a = ((double)AchievementsEarned / (double)TotalAchievements * 100);
                return Math.Round(a, 2, MidpointRounding.ToEven);
            }
        }


        public string ProgressText
        {
            get
            {
                return string.Format("{0} of {1}", AchievementsEarned, TotalAchievements);
            }
        }


        public bool HasAchievements { get { return !string.IsNullOrEmpty(this.StatsLink); } }
        public bool BeenProcessed { get { return this.AchievementRefresh > new DateTime(2001, 2, 1); } }

        public string RecentHoursFormatted
        {
            get
            {
                return string.Format("{0} hrs", this.RecentHours);
            }
        }
        public string TotalHoursFormatted
        {
            get
            {
                return string.Format("{0} hrs", this.HoursPlayed);
            }
        }



        public string PercentCompleteFormatted
        {
            get
            {
                if (TotalAchievements > 0)
                {
                    return string.Format("{0}%", this.PercentComplete);
                }
                return "0%";
            }
        }

        public Game()
        {
            this.SteamUserID = 0;
            this.AppID = 0;
            this.Name = string.Empty;
            this.StatsLink = string.Empty;
            this.GameLink = string.Empty;
            this.Logo = string.Empty;
            this.HoursPlayed = 0;
            this.RecentHours = 0;
            this.LastUpdated = DateTime.Now;
            this.AchievementRefresh = new DateTime(1900, 1, 1);
            this.AchievementsEarned = 0;
            this.TotalAchievements = 0;
        }

        //This is for updating
        public Game(gamesListGame g, long steamID64)
        {
            this.SteamUserID = steamID64;
            this.AppID = g.appID;
            this.Name = g.name;
            this.StatsLink = g.statsLink;
            this.GameLink = g.storeLink;
            this.Logo = g.logo;
            this.HoursPlayed = g.hoursOnRecord;
            this.RecentHours = g.hoursLast2Weeks;
            this.LastUpdated = DateTime.Now;
            //this.AchievementRefresh = new DateTime(1900, 1, 1);
            this.AchievementsEarned = 0;
            this.TotalAchievements = 0;
        }

    }
}
