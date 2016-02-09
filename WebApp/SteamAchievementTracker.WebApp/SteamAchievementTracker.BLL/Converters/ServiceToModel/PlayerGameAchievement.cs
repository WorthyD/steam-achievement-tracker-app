using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.Contracts.Models;

namespace SteamAchievementTracker.BLL.Converters.ServiceToModel
{
    public static class PlayerGameAchievement
    {
        public static void ConvertService(this IPlayerGameAchievement pga, long appId, long steamId, SteamApiWrapper.Models.PlayerAchievements.Achievement a)
        {
            //pga.AchievementIcon = a.
            pga.Achieved = (a.achieved == 1) ? true : false;
            pga.ApiName = a.apiname;
            pga.AppID = appId;
            pga.SteamId = steamId;
        }
    }
}
