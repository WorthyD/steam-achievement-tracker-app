using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.DataModel {
    public class Game {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Logo { get; set; }
        public decimal HoursPlayed { get; set; }
        public decimal HoursOnRecord { get; set; }

    }
}
