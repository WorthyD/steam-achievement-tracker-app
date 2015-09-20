using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.Contracts.Models;

namespace SteamAchievementTracker.DataAccess.Models {
    public class PlayerGameAchievements : IPlayerGameAchievement
    {


        [Key, Column(Order = 10)]
       // [ForeignKey("PlayerProfile")]
        public long PlayerID64 { get; set; }

        [Key, Column(Order = 20)]
        //[ForeignKey("PlayerGame")]
        public int AppID { get; set; }


        [Key, Column(Order = 30)]
        [StringLength(250)]
        public string AchievementID { get; set; }

        [Required]
        [StringLength(250)]
        public string StatsURL { get; set; }

        [Required]
        public bool IsUnlocked { get; set; }

        [Required]
        [StringLength(250)]
        public string AchievementIcon { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public string UnlockTimestamp { get; set; }

        public virtual PlayerProfile PlayerProfile { get; set; }
        public virtual PlayerGame PlayerGame { get; set; }
    }
}
