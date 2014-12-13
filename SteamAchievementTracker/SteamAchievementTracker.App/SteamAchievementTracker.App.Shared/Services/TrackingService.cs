using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.Services {
    public class TrackingService {
        public void TrackEvent(string cat, string action, string label) {

            var t = GoogleAnalytics.EasyTracker.GetTracker();
            t.SendEvent(cat, action, label, 0);
        }
    }
}
