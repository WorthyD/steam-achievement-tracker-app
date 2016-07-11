using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.Contracts.Models;

namespace SteamAchievementTracker.DataAccess.Models {
    public class ProfileRecentGame : IProfileRecentGame
    {

        [Key, Column(Order = 10)]
        [ForeignKey("PlayerProfile")]
        [Required]
        public long SteamId { get; set; }

        [Key, Column(Order = 20)]
        [ForeignKey("GameSchema")]
        [Required]
        public long AppId { get; set; }

        public virtual PlayerProfile PlayerProfile { get; set; }
        //public virtual PlayerGame PlayerGame { get; set; }
        public virtual GameSchema GameSchema { get; set; }
    }
}
