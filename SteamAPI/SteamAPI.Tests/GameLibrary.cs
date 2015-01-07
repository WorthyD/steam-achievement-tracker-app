using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Tests {
    [TestClass]
    public class GameLibrary {
        [TestMethod]
        public async Task W8GetPlayerGamesByName() {
            bool isTrue = await Agnostic.GameLibrary.GetPlayerGamesByName();
            Assert.IsTrue(isTrue);
        }
    }
}
