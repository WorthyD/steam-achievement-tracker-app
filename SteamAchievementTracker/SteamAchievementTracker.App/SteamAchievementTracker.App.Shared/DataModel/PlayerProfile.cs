using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.DataModel {
    public partial class PlayerProfile {
        public ulong ID64 { get; set; }
        public string ID { get; set; }

        public string Name { get; set; }
        public string ThumbURL { get; set; }

        public List<Game> RecentGames{ get; set; }
    }
}
