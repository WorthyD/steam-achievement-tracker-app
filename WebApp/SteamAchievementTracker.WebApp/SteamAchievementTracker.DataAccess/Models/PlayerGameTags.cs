using SteamAchievementTracker.Contracts.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DataAccess.Models {
    public class PlayerGameTags : IPlayerGameTags{




        [ForeignKey("PlayerProfiles")]
        public long PlayerID64 { get; set; }

        [ForeignKey("PlayerGames")]
        public int AppID { get; set; }

        public string Tag { get; set; }


     
    }
}
