using SteamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                ///psg.gameName = xg
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
