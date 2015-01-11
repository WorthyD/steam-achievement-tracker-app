using SteamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SteamAPI.Extensions;

namespace SteamAPI.Converters {
    public static class Game {
        public static gamesList StringToGameList(this string gl) {

            gamesList retVal = new gamesList();

            List<gamesListGame> gameList = new List<gamesListGame>();

            XDocument doc = XDocument.Parse(gl);
            var r = doc.Root;
            var mrg = r.Element("games");
            if (mrg != null) {
                var gs = mrg.Descendants("game");
                foreach (var x in gs) {

                    gameList.Add(x.ConvertToGame());
                }
            }

            retVal.games = gameList.ToArray();

            return retVal;
        }
        public  static gamesListGame ConvertToGame(this XElement x) {
            gamesListGame g = new gamesListGame();
            g.appID = x.GetInt32Element("appID", 0);
            g.name = x.GetStringValue("name");
            g.logo = x.GetStringValue("logo");
            g.storeLink = x.GetStringValue("storeLink");
            g.hoursLast2Weeks = x.GetDecimalElement("hoursLast2Weeks", 0);
            g.hoursOnRecord = x.GetDecimalElement("hoursOnRecord", 0);
            g.statsLink = x.GetStringValue("statsLink");

            return g;
        }
    }
}
