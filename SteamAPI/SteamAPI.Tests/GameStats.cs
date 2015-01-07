using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Tests {
    [TestClass]
    public class GameStats {
        [TestMethod]
        public async Task W8GetGameStats() {
            bool isTrue = await Agnostic.GameStats.GetPlayerGameStats("http://steamcommunity.com/id/WorthyD/stats/L4D2");
            Assert.IsTrue(isTrue);
        }
    }
}
