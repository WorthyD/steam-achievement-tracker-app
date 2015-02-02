using SteamAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Tests.Agnostic {
    public class GameStats {
        public static async Task<bool> GetPlayerGameStats(string url) {
            SteamAPI.Player.PlayerGameStatsRequest request = new SteamAPI.Player.PlayerGameStatsRequest();
            //request.GameUrl = "http://steamcommunity.com/id/WorthyD/stats/L4D2";
            //request.GameUrl = "http://steamcommunity.com/id/WorthyD/stats/Borderlands";
            request.GameUrl = url;
            var resposne = await request.GetResponse();

            return AnythingEmpty(resposne);
        }
        public static async Task<bool> GetPlayerGameStatsEmpty(string url) {
            SteamAPI.Player.PlayerGameStatsRequest request = new SteamAPI.Player.PlayerGameStatsRequest();

            request.GameUrl = url;
            var p = await request.GetResponse();

            if (p != null && p.PlayerStats.game != null && p.PlayerStats.achievements != null) {
                var g = p.PlayerStats.game;
                var achs = p.PlayerStats.achievements;

                if (achs.Where(x => x.closed == false).Count() == achs.Count()) {
                    return true; 
                }
            }

            return false;
        }
        public static async Task<bool> GetPlayerGameStatsFull(string url) {
            SteamAPI.Player.PlayerGameStatsRequest request = new SteamAPI.Player.PlayerGameStatsRequest();

            request.GameUrl = url;
            var p = await request.GetResponse();

            if (p != null && p.PlayerStats.game != null && p.PlayerStats.achievements != null) {
                var g = p.PlayerStats.game;
                var achs = p.PlayerStats.achievements;

                if (achs.Where(x => x.closed == true).Count() == achs.Count()) {
                    return true;
                }
            }

            return false;
        }

        public static bool AnythingEmpty(PlayerGameStatsResponse p) {
            if (p != null && p.PlayerStats.game != null && p.PlayerStats.achievements != null) {
                var g = p.PlayerStats.game;
                var achs = p.PlayerStats.achievements;

                if (g.gameIcon.IsEmpty() ||
                    g.gameLink.IsEmpty() ||
                    g.gameLogo.IsEmpty() ||
                    g.gameName.IsEmpty()
                    ) {
                    return false;
                }


                if (achs.Count() == 0) {
                    return false;
                }
                if (achs.Where(x => x.closed == true).Count() == 0) {
                    return false;
                }

                if (achs.Where(x => x.closed == false).Count() == 0) {
                    return false;
                }




                var a = achs.FirstOrDefault();

                if (a.iconClosed.IsEmpty() ||
                    a.iconOpen.IsEmpty() ||
                    a.name.IsEmpty() ||
                    a.description.IsEmpty()) {
                    return false;
                }

                return true;



            }
            return false;

        }
    }
}
