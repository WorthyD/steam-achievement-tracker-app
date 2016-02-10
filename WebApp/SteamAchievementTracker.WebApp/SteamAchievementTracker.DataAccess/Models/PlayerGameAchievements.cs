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
    public class PlayerGameAchievement : IPlayerGameAchievement
    {


        [Key, Column(Order = 10), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("PlayerGame")]
        public long SteamId { get; set; }

        [Key, Column(Order = 20), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("PlayerGame")]
        public long AppID { get; set; }

        [Key, Column(Order = 30)]
        [StringLength(250)]
        public string ApiName { get; set; }

        [Required]
        public bool Achieved { get; set; }

        [Required]
        public DateTime UnlockTimestamp { get; set; }

        [ForeignKey("SteamId")]
        public virtual PlayerProfile PlayerProfile { get; set; }
        //[ForeignKey("SteamId")]
        public virtual PlayerGame PlayerGame { get; set; }
        //public virtual GameSchema GameSchema { get; set; }
    }
}
