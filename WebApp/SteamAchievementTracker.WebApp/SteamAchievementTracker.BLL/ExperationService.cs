using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL
{
    public static class ExperationService
    {
        public static bool isProfileExpired(DateTime lastUpdate)
        {
            return lastUpdate < DateTime.Now.AddDays(-1);
        }
    }
}
