using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DataAccess.Models {
    public class ProfileRecentGame {
        public long ID64 { get; set; }
        public string GameLink { get; set; }
    }
}
