using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.Contracts.Models;

namespace SteamAchievementTracker.DataAccess.Models
{
    public class PlayerGame : IPlayerGame
    {


        [ForeignKey("PlayerProfiles")]
        [Key, Column(Order = 10)]
        public long SteamId { get; set; }

        [Key, Column(Order = 20)]
        public int AppID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public decimal Playtime_Forever { get; set; }

        [Required]
        public decimal Playtime_2weeks { get; set; }



        [Required]
        [StringLength(250)]
        public string Img_Icon_Url { get; set; }


        [Required]
        [StringLength(250)]
        public string Img_Logo_Url { get; set; }


        [Required]
        public bool has_community_visible_stats { get; set; }



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


      
        public bool BeenProcessed { get; set; }
        public double PercentComplete { get; set; }



        public virtual PlayerProfile PlayerProfiles { get; set; }

        public virtual IList<PlayerGameAchievements> PlayerGameAchievements { get; set; }
        public virtual IList<ProfileRecentGame> ProfileRecentGames { get; set; } 
    }
}
