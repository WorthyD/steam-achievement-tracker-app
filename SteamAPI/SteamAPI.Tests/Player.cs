using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;

namespace SteamAPI.Tests {
    [TestClass]
    public class Player {

        [TestMethod]
        public async Task W8GetPlayerProfileByName() {
            bool isTrue = await Agnostic.Profile.GetPlayerProfileByName();
            Assert.IsTrue(isTrue);
        }
        [TestMethod]
        public async Task W8GetPlayerProfileByID() {
            bool isTrue = await Agnostic.Profile.GetPlayerProfileByID();
            Assert.IsTrue(isTrue);
        }


        [TestMethod]
        public async Task GetPlayerGames() {
            SteamAPI.Player.PlayerGamesRequest request = new SteamAPI.Player.PlayerGamesRequest();
            request.SteamID = "WorthyD";
            var response = await request.GetResponse();

            Assert.IsTrue(response.GamesList.games.Where(x=> x.name == "Borderlands").Count() > 0);
        }

        [TestMethod]
        public async Task GetPlayerGameStats() {
            SteamAPI.Player.PlayerGameStatsRequest request = new SteamAPI.Player.PlayerGameStatsRequest();
            request.GameUrl = "http://steamcommunity.com/id/WorthyD/stats/L4D2";
            //request.GameUrl = "http://steamcommunity.com/id/WorthyD/stats/Borderlands";
            var resposne = await request.GetResponse();
            Assert.IsTrue(resposne.PlayerStats.achievements.Where(x => x.closed == true).Count() > 0);
        }


    }
}
