using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.TestsPhone {
    [TestClass]
    public class Player {

        [TestMethod]
        public async Task PhoneGetPlayerProfile() {
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = "WorthyD";
            var response = await request.GetResponse();

            Assert.IsTrue(response.Profile.steamID == "WorthyD");
        }


        [TestMethod]
        public async Task PhoneGetPlayerGames() {
            SteamAPI.Player.PlayerGamesRequest request = new SteamAPI.Player.PlayerGamesRequest();
            request.SteamID = "WorthyD";
            var response = await request.GetResponse();

            Assert.IsTrue(response.GamesList.games.Where(x => x.name == "Borderlands").Count() > 0);
        }

        [TestMethod]
        public async Task PhoneGetPlayerGameStats() {
            SteamAPI.Player.PlayerGameStatsRequest request = new SteamAPI.Player.PlayerGameStatsRequest();
            request.GameUrl = "http://steamcommunity.com/id/WorthyD/stats/L4D2";
            //request.GameUrl = "http://steamcommunity.com/id/WorthyD/stats/Borderlands";
            var resposne = await request.GetResponse();
            Assert.IsTrue(resposne.PlayerStats.achievements.Where(x => x.closed == true).Count() > 0);
        }


    }
}
