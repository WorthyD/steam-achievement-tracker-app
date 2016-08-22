﻿using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.WebApi.ViewModels
{
    public class GameDetails : IPlayerGame, IGameSchema
    {

        public long SteamId { get; set; }
        public long AppID { get; set; }
        public string Name { get; set; }
        public decimal Playtime_Forever { get; set; }
        public decimal Playtime_2weeks { get; set; }
        public string Img_Icon_Url { get; set; }
        public string Img_Logo_Url { get; set; }
        public bool has_community_visible_stats { get; set; }
        public bool has_achievements { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime AchievementRefresh { get; set; }
        public bool RefreshAchievements { get; set; }
        public int AchievementsEarned { get; set; }
        public int AchievementsLocked { get; set; }
        public int TotalAchievements { get; set; }



        public bool BeenProcessed
        {
            get; set;
        }
        public int PercentComplete
        {
            get; set;
        }

        public List<GameAchievement> UnlockedAchievements { get; set; }
        public List<GameAchievement> LockedAchievements { get; set; }

        public long AppId
        {
            get;
            set;
        }

        public DateTime LastSchemaUpdate
        {
            get;

            set;
        }

        public bool HasAchievements
        {
            get;
            set;
        }

        private void ApplyBase(IPlayerGame pg, IGameSchema gs)
        {
            this.SteamId = pg.SteamId;
            this.AppID = pg.AppID;
            //this.Name = pg.Name;
            this.Playtime_Forever = pg.Playtime_Forever;
            this.Playtime_2weeks = pg.Playtime_2weeks;
            this.Img_Icon_Url = gs.Img_Icon_Url;
            this.Img_Logo_Url = gs.Img_Logo_Url;
            this.has_community_visible_stats = gs.has_community_visible_stats;
            this.has_achievements = gs.HasAchievements;
            this.LastUpdated = pg.LastUpdated;
            this.AchievementRefresh = pg.AchievementRefresh;
            this.RefreshAchievements = pg.RefreshAchievements;
            this.AchievementsEarned = pg.AchievementsEarned;
            this.AchievementsLocked = pg.AchievementsLocked;
            this.TotalAchievements = pg.TotalAchievements;
            //this.GameAchievements = new List<GameAchievement>();
            this.UnlockedAchievements = new List<GameAchievement>();
            this.LockedAchievements = new List<GameAchievement>();

            this.BeenProcessed = this.AchievementRefresh >new DateTime(2000, 1, 1);
            int perc = 0;
            if (this.TotalAchievements > 0)
            {
                perc = (int)(((decimal)this.AchievementsEarned / (decimal)this.TotalAchievements) * 100);
            }
            this.PercentComplete = perc;

        }


        public GameDetails(IPlayerGame pg, IGameSchema gs)
        {
            this.ApplyBase(pg, gs);
        }

        public GameDetails(DataAccess.Models.PlayerGame pg, DataAccess.Models.GameSchema gs, List<DataAccess.Models.GameAchievement> gas, List<DataAccess.Models.PlayerGameAchievement> pgas)
        {
            this.ApplyBase(pg, gs);
            foreach (var ga in gas)
            {
                var pga = pgas.Where(x => x.ApiName == ga.Name).FirstOrDefault();

                var game = new GameAchievement(pga, ga);
                if (pga.Achieved == true)
                {
                    this.UnlockedAchievements.Add(game);
                }
                else
                {
                    this.LockedAchievements.Add(game);
                }
            }
        }
    }

}
