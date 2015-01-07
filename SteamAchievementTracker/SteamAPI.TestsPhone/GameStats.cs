using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.TestsPhone {
    [TestClass]
    public class GameStats {
        [TestMethod]
        public async Task WP8GetGameStats() {
            bool isTrue = await SteamAPI.Tests.Agnostic.GameStats.GetPlayerGameStats("http://steamcommunity.com/id/WorthyD/stats/L4D2");
            Assert.IsTrue(isTrue);
        }
    }
}
