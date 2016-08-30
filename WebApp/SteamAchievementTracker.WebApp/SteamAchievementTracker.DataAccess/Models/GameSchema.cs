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
    public class GameSchema : IGameSchema
    {
        [Required]
        [Key, Column(Order = 10), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AppId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public DateTime LastSchemaUpdate { get; set; }


        [Required]
        public bool HasAchievements { get; set; }

        [Required]
        [StringLength(250)]
        public string Img_Icon_Url { get; set; }

        [Required]
        [StringLength(250)]
        public string Img_Logo_Url { get; set; }



        public virtual List<GameAchievement> GameAchievements { get; set; }

        public virtual List<PlayerGame> PlayerGames { get; set; }

        [Required]
        public bool has_community_visible_stats
        {
            get; set;
        } 

        [Required]
        public int AvgUnlock { get; set; }


        //IList<IGameAchievement> IGameSchema.GameAchievements
        //{
        //    get
        //    {
        //        //  throw new NotImplementedException();
        //        return GameAchievements as IList<IGameAchievement>;
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //IList<IGameAchievement> IGameSchema.GameAchievements
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
