using System;
using SteamAchievementTracker.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL.Converters.ServiceToModel {
    public static class GameAchievement {
        public static void ConvertService(this IGameAchievement ia, long appId, SteamApiWrapper.Models.SchemaForGame.Achievement a, SteamApiWrapper.Models.GlobalAchievementPercentages.Achievement ap) {
            ia.AppId = appId;
            ia.DisplayName = a.displayName;
            ia.Description = (string.IsNullOrEmpty( a.description))? string.Empty :  Substring(a.description, 325);
            ia.Hidden = a.hidden == 1 ? true : false;
            ia.Icon = a.icon;
            ia.IconGray = a.icongray;
            ia.Name = a.name;
                ia.Percent = (ap != null) ? ap.percent : 0;
        }

        private static string Substring(string str, int count)
        {
            if (str.Length<= count)
            {
                return str;
            }
            else
            {
                return str.Substring(0, count);
            }
        }
    }
}
