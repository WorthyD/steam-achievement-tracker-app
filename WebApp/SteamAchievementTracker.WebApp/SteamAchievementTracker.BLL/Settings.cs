using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL {
    public static class Settings {
        public static DateTime ProfileExpiration {
            get {
                return DateTime.Now.AddDays(-1);
            }
        }
    }
}
