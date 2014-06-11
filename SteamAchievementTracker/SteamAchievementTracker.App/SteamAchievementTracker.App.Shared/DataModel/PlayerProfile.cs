using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.DataModel {
    public class PlayerProfile {
        public ulong ID64 { get; set; }
        public string ID { get; set; }

        public string Name { get; set; }
    }
}
