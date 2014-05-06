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
        public async Task GetPlayerProfile() {
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = "WorthyD";
            var response =  await  request.GetResponse();

            SteamAPI.Models.Profile p = new Models.Profile();

            Assert.IsTrue(response.Profile.steamID == "WorthyD");
        }
    }
}
