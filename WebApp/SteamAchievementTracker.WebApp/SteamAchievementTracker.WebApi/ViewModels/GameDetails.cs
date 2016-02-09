using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.WebApi.ViewModels
{
    public class GameDetails : IPlayerGame
    {

        public long SteamId { get; set; }
        public long AppID { get; set; }
        public string Name { get; set; }
        public decimal Playtime_Forever { get; set; }
        public decimal Playtime_2weeks { get; set; }
        public string Img_Icon_Url { get; set; }
        public string Img_Logo_Url { get; set; }
        public bool has_community_visible_stats { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime AchievementRefresh { get; set; }
        public bool RefreshAchievements { get; set; }
        public int AchievementsEarned { get; set; }
        public int AchievementsLocked { get; set; }
        public int TotalAchievements { get; set; }



        public bool BeenProcessed
        {
            get
            {
                return this.AchievementRefresh > DateTime.MinValue;
            }
        }
        public double PercentComplete
        {
            get
            {
                if (this.TotalAchievements > 0)
                {
                    return this.AchievementsEarned / this.TotalAchievements;
                }
                return 0;
            }
        }

        public List<GameAchievement> Achievements { get; set; }

        private void ApplyBase(IPlayerGame pg)
        {
            this.SteamId = pg.SteamId;
            this.AppID = pg.AppID;
            this.Name = pg.Name;
            this.Playtime_Forever = pg.Playtime_Forever;
            this.Playtime_2weeks = pg.Playtime_2weeks;
            this.Img_Icon_Url = pg.Img_Icon_Url;
            this.Img_Logo_Url = pg.Img_Logo_Url;
            this.has_community_visible_stats = pg.has_community_visible_stats;
            this.LastUpdated = pg.LastUpdated;
            this.AchievementRefresh = pg.AchievementRefresh;
            this.RefreshAchievements = pg.RefreshAchievements;
            this.AchievementsEarned = pg.AchievementsEarned;
            this.AchievementsLocked = pg.AchievementsLocked;
            this.TotalAchievements = pg.TotalAchievements;
            this.Achievements = new List<GameAchievement>();

        }


        public GameDetails(IPlayerGame pg)
        {
            this.ApplyBase(pg);
        }

        public GameDetails(IPlayerGame pg, List<IGameAchievement> gas, List<IPlayerGameAchievement> pgas)
        {
            this.ApplyBase(pg);
            foreach (var ga in gas)
            {
                var pga = pgas.Where(x => x.ApiName == ga.Name).FirstOrDefault();

                this.Achievements.Add(new GameAchievement(pga, ga));
            }
        }
    }

}
