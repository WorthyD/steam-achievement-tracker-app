using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DataAccess.Models {
    public class PlayerGameTags {

        public long PlayerID64 { get; set; }

        public int AppID { get; set; }

        public string Tag { get; set; }

    }
}
