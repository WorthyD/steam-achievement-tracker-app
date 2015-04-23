using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DataAccess.Models {
    public class PlayerProfile {

        [Key]
        [Required]
        public long PlayerID64 { get; set; }

        [Required]
        public string CustomUrl { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ThumbURL { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }


        public virtual IList<PlayerGame> PlayerGames {get;set;}
        public virtual IList<ProfileRecentGame> PlayerRecentGames {get;set;}
        public virtual IList<PlayerGameAchievements> PlayerGameAchievements {get;set;}





    }
}
