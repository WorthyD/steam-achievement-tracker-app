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
    //Todo add game table for better updating
    public class GameAchievement : IGameAchievement
    {
        [Required]
        [Key, Column(Order = 10),  DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("GameSchema")]
        public long AppId { get; set; }

        [Key, Column(Order = 20)]
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string DisplayName { get; set; }

        public bool Hidden { get; set; }

        [Required]
        [StringLength(250)]
        public string Icon { get; set; }

        [Required]
        [StringLength(250)]
        public string IconGray { get; set; }
        
        public double Percent { get; set; }

        public virtual GameSchema GameSchema { get; set; }


    }
}
