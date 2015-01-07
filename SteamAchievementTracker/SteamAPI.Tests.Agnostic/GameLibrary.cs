using SteamAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Tests.Agnostic {
    public class GameLibrary {

        public static async Task<bool> GetPlayerGamesByName() {
            SteamAPI.Player.PlayerGamesRequest request = new SteamAPI.Player.PlayerGamesRequest();
            request.SteamID = "WorthyD";
            var response = await request.GetResponse();


            return AnythingEmpty(response);
        }
        public static bool AnythingEmpty(PlayerGamesResponse pgp) {

            if (pgp.GamesList.games == null || pgp.GamesList.games.Count() == null) {
                return false;
            }
            var g = pgp.GamesList.games.FirstOrDefault();

            if (g.appID == 0 ||
                g.logo.IsEmpty() ||
                g.name.IsEmpty() ||
                g.storeLink.IsEmpty()
               ) {
                return false;
            }
            return true;

        }
    }
}
