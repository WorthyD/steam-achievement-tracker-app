using System;
using SteamAchievementTracker.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL.Converters.ServiceToModel
{
    public static class PlayerGame
    {
        public static void ConvertService(this IPlayerGame ig, SteamApiWrapper.Models.OwnedGames.Game g, long steamId)
        {
            ig.AppID = g.appid;
            /*
            ig.has_community_visible_stats = g.has_community_visible_stats;
            ig.Img_Icon_Url = (string.IsNullOrEmpty( g.img_icon_url )) ? "Not Found" : g.img_icon_url;
            ig.Img_Logo_Url =  (string.IsNullOrEmpty(g.img_logo_url )) ? "Not Found" : g.img_logo_url;
            ig.Name = g.name ?? string.Empty;
            */
            ig.SteamId = steamId;
            ig.Playtime_2weeks = g.playtime_2weeks;
            ig.Playtime_Forever = g.playtime_forever;
        }
    }
}
