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
        //[ForeignKey("PlayerProfile")]
        public long ID64 { get; set; }

        [Key, Column(Order = 20)]
        //[ForeignKey("PlayerGame")]
        public int AppID { get; set; }

        public virtual PlayerProfile PlayerProfile { get; set; }
        public virtual PlayerGame PlayerGame { get; set; }
    }
}
