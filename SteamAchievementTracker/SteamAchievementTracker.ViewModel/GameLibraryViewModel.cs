using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.ViewModel
{
    public class GameLibraryViewModel
    {
        public List<GameListItemViewModel> GameList { get; set; }
    }

    public class GameListItemViewModel : IGame
    {
        public GameListItemViewModel(IGame g)
        {
            this.SteamUserID = g.SteamUserID;
            this.AppID = g.AppID;
            this.Name = g.Name;
            this.StatsLink = g.StatsLink;
            this.GameLink = g.GameLink;
            this.Logo = g.Logo;
            this.HoursPlayed = g.HoursPlayed;
            this.RecentHours = g.RecentHours;
            this.LastUpdated = g.LastUpdated;
            this.AchievementRefresh = g.AchievementRefresh;
            this.AchievementsEarned = g.AchievementsEarned;
            this.TotalAchievements = g.TotalAchievements;
        }


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

        public string PercentComplete
        {
            get
            {
                return (AchievementsEarned / TotalAchievements).ToString();                //return AchievementsEarned / TotalAchievements;
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
        public bool BeenProcessed { get { return this.LastUpdated > new DateTime(1900, 2, 1); } }
    }
}
