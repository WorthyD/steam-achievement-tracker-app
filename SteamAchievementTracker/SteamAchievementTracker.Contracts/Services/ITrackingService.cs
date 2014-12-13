using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Services {
    public interface ITrackingService {
        //public void TrackEvent(string )
         void TrackEvent(string cat, string action, string label);
    }
}
