using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL.Converters.ServiceToModel
{
    public static class PlayerProfile
    {

        public static void ConvertService(this IPlayerProfile ip, SteamApiWrapper.Models.PlayerSummaries.Player p)
        {
            ip.AvatarFull = p.avatarfull;
            ip.PersonaName = p.personaname;
            ip.ProfileUrl = p.profileurl;
            ip.RealName = !string.IsNullOrEmpty(p.realname) ? p.realname : "Not Found";
            ip.SteamId = long.Parse(p.steamid);
        }
    }
}
