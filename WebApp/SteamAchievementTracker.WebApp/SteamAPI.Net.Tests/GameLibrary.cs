using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SteamAPI.Net.Tests {
    [TestClass]
    public class GameLibrary {
        [TestMethod]
        public async Task NetGetPlayerGamesByName() {
            bool isTrue = await SteamAPI.Tests.Agnostic.GameLibrary.GetPlayerGamesByName();
            Assert.IsTrue(isTrue);
        }
    }
}
