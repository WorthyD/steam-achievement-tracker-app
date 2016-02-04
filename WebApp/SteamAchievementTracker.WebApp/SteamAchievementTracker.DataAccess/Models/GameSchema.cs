using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DataAccess.Models
{
    public class GameSchema
    {
        [Required]
        [Key, Column(Order = 10), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AppId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

       [Required]
        public DateTime LastSchemaSUpdate { get; set; }


        [Required]
        public DateTime LastAchievementUpdate { get; set; }

        [Required]
        public bool HasAchievements { get; set; }



        public virtual IList<GameAchievement> GameAchievements { get; set; }
    }
}
