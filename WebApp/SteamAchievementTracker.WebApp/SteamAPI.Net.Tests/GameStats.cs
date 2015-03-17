using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SteamAPI.Net.Tests {
    [TestClass]
    public class GameStats {
        [TestMethod]
        public async Task NetGetGameStats() {
            bool isTrue = await SteamAPI.Tests.Agnostic.GameStats.GetPlayerGameStats("http://steamcommunity.com/id/WorthyD/stats/L4D2");
            Assert.IsTrue(isTrue);
        }
        [TestMethod]
        public async Task NetGetGameStatsEmpty() {
            bool isTrue = await SteamAPI.Tests.Agnostic.GameStats.GetPlayerGameStatsEmpty("http://steamcommunity.com/id/WorthyD/stats/AlanWake");
            Assert.IsTrue(isTrue);
        }
        [TestMethod]
        public async Task NetGetGameStatsFull() {
            bool isTrue = await SteamAPI.Tests.Agnostic.GameStats.GetPlayerGameStatsFull("http://steamcommunity.com/id/WorthyD/stats/284870/");
            Assert.IsTrue(isTrue);
        }


    }
}
