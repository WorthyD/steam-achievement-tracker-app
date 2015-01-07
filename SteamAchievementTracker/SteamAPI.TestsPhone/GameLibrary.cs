using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.TestsPhone {
    [TestClass]
    public class GameLibrary {
        [TestMethod]
        public async Task WP8GetPlayerGamesByName() {
            bool isTrue = await SteamAPI.Tests.Agnostic.GameLibrary.GetPlayerGamesByName();
            Assert.IsTrue(isTrue);
        }
    }
}
