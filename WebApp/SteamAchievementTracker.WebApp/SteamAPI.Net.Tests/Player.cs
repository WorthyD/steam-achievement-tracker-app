using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Net.Tests {
    [TestClass]
    public class Player {
        [TestMethod]
        public async Task W8GetPlayerProfileByName() {
            bool isTrue = await SteamAPI.Tests.Agnostic.Profile.GetPlayerProfileByName();
            Assert.IsTrue(isTrue);
        }
        [TestMethod]
        public async Task W8GetPlayerProfileByID() {
            bool isTrue = await SteamAPI.Tests.Agnostic.Profile.GetPlayerProfileByID();
            Assert.IsTrue(isTrue);
        }
        [TestMethod]
        public async Task W8GetPlayerProfileByNameLIGHT() {
            bool isTrue = await SteamAPI.Tests.Agnostic.Profile.GetPlayerProfileByNameLIGHT();
            Assert.IsTrue(isTrue);
        }
        [TestMethod]
        public async Task W8GetPlayerProfileByIDLIGHT() {
            bool isTrue = await SteamAPI.Tests.Agnostic.Profile.GetPlayerProfileByIDLIGHT();
            Assert.IsTrue(isTrue);
        }


    }
}
