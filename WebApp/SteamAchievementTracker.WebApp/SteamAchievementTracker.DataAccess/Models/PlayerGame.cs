using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DataAccess.Models {
    public class PlayerGame {


        [Key, Column(Order = 10)]
        public long PlayerID64 { get; set; }

        [Key, Column(Order = 20)]
        public int AppID { get; set; }


        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public string StatsLink { get; set; }

         [Required]
        [StringLength(250)]
 
        public string GameLink { get; set; }

        [Required]
        [StringLength(250)]
        public string Logo { get; set; }

        [Required]
        [StringLength(250)]
 
        public string Icon { get; set; }

        [Required]
        public decimal HoursPlayed { get; set; }

        [Required]
        public decimal RecentHours { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public DateTime AchievementRefresh { get; set; }

        [Required]
        public bool RefreshAchievements { get; set; }

        [Required]
        public int AchievementsEarned { get; set; }

        [Required]
        public int AchievementsLocked { get; set; }

        [Required]
        public int TotalAchievements { get; set; }


        [Required]
        public bool HasAchievements { get; set; }

        public bool BeenProcessed { get;}
        public double PercentComplete { get; }


    }
}
