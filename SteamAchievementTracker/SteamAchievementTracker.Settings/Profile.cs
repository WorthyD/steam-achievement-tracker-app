using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Settings
{
    public static class Profile
    {
        public static int ProfileRefreshInterval
        {
            get
            {
                //return 60;
                return 0;
            }
        }

        public static bool GetGamesWOAchievements
        {
            get
            {
                bool showNoAch = false;
                var showNoAchObj = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ShowNoAch"];
                if (showNoAchObj != null)
                {
                    bool.TryParse(showNoAchObj.ToString(), out showNoAch);
                }
                return showNoAch;
            }
        }
    }
}
