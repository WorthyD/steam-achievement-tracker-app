using SteamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SteamAPI.Extensions;

namespace SteamAPI.Converters {
    public static class Stats {
        public static Models.playerstats StringToStatsList(this string s) {

            Models.playerstats gs = new Models.playerstats();
            List<playerstatsAchievement> gsa = new List<playerstatsAchievement>();
            playerstatsGame psg = new playerstatsGame();


            XDocument doc = XDocument.Parse(s);
            var r = doc.Root;

            var xg = r.Element("game");
            if (xg != null){
                psg.gameName = xg.GetStringValue("gameName");
                psg.gameLink = xg.GetStringValue("gameLink");
                psg.gameIcon = xg.GetStringValue("gameIcon");
                psg.gameLogo = xg.GetStringValue("gameLogo");
                gs.game = psg;

                var gas = r.Element("achievements").Descendants("achievement");
                if (gas != null) {
                    foreach (var x in gas) {
                        var ach = new playerstatsAchievement();
                        ach.closed = x.GetBooleanAttribute("closed", false);
                        ach.iconClosed = x.GetStringValue("iconClosed");
                        ach.iconOpen = x.GetStringValue("iconOpen");

                        ach.name = x.GetStringValue("name");
                        ach.apiname = x.GetStringValue("apiname");
                        ach.description = x.GetStringValue("description");
                        ach.unlockTimestamp = x.GetuinElement("unlockTimestamp", 0);

                        gsa.Add(ach);
                    }
                    gs.achievements = gsa.ToArray(); 
                }
                return gs;
            }







            //var mrg = r.Element("games");
            //if (mrg != null) {
            //    var g = mrg.Descendants("game");
            //    foreach (var x in g) {

            //        gameList.Add(x.ConvertToGame());
            //    }
            //}

            //retVal.games = gameList.ToArray();


            return null;
        }
    }
}
