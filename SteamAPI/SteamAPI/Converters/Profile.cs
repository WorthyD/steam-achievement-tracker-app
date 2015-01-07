using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SteamAPI.Extensions;

namespace SteamAPI.Converters {
    public static class Profile {
        public static Models.Profile.profile StringToProfile(this string pro) {
            var m = new Models.Profile.profile();

            XDocument doc = XDocument.Parse(pro);
            var r = doc.Root;
            //m.avatarFull = r.Element("avatarFull").Value;
            m.steamID64 = r.GetInt64Element("steamID64", 0);
            m.steamID = r.GetStringValue("steamID");

            m.avatarIcon = r.GetStringValue("avatarIcon");
            m.avatarMedium = r.GetStringValue("avatarMedium");
            m.avatarFull = r.GetStringValue("avatarFull");


            m.customURL = r.GetStringValue("customURL");
            m.realname = r.GetStringValue("realname");

            //Get most recent games

            var gameList = new List<Models.Profile.profileMostPlayedGame>();
            var mrg = r.Element("mostPlayedGames");

            if (mrg != null) {
                var gs = mrg.Descendants("mostPlayedGame");
                if (gs != null) {
                    foreach (var x in gs) {
                        Models.Profile.profileMostPlayedGame g = new Models.Profile.profileMostPlayedGame();
                        g.gameLink = x.GetStringValue("gameLink");
                        gameList.Add(g);
                    }
                }

            }

            m.mostPlayedGames = gameList.ToArray();

            return m;
        }
    }
}
