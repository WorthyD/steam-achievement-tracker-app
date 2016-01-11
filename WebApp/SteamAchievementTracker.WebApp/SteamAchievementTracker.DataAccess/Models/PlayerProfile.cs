using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.Contracts.Models;

namespace SteamAchievementTracker.DataAccess.Models {
    public class PlayerProfile : IPlayerProfile{

        [Key]
        [Required]
        public long SteamId { get; set; }

        [Required]
        [StringLength(250)]
        public string PersonaName { get; set; }

        [Required]
        [StringLength(250)]
        public string RealName { get; set; }

        [Required]
        [StringLength(250)]
        public string AvatarFull { get; set; }

        [Required]
        [StringLength(250)]
        public string ProfileUrl { get; set; }



        [Required]
        public DateTime LastUpdate { get; set; }

        [Required]
        public DateTime LibraryLastUpdate { get; set; }



        public virtual IList<PlayerGame> PlayerGames {get;set;}
        public virtual IList<ProfileRecentGame> PlayerRecentGames {get;set;}
        public virtual IList<PlayerGameAchievements> PlayerGameAchievements {get;set;}





    }
}
