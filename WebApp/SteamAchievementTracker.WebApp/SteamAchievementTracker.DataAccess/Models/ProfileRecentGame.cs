using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.Contracts.Models;

namespace SteamAchievementTracker.DataAccess.Models {
    public class ProfileRecentGame : IProfileRecentGame{
            
        [ForeignKey("PlayerProfiles")]
        public long ID64 { get; set; }

        [ForeignKey("PlayerGames")]
        public int AppID { get; set; }
    }
}
