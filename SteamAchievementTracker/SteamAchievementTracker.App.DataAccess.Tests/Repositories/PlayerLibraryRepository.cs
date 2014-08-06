using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace SteamAchievementTracker.App.DataAccess.Tests.Repositories {
    [TestClass]
    public class PlayerLibraryRepository {
        [TestMethod]
        public async Task GetPlayerProfile() {
            DataAccess.Repository.PlayerProfileRepository _repo = new Repository.PlayerProfileRepository();
            var p = await _repo.GetProfileCached(0, "WorthyD");

            var result = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "\\localstate\\SteamAchievementTracker.db");
         
            Debug.WriteLine(result);
            Assert.IsTrue(p.ID == "WorthyD");
        }

        [TestMethod]
        public async Task GetPlayerLibrary() {
            DataAccess.Repository.PlayerProfileRepository _repo = new Repository.PlayerProfileRepository();
            DataAccess.Repository.PlayerLibraryRepository _glRepo = new Repository.PlayerLibraryRepository();
            var p = await _repo.GetProfileCached(0, "WorthyD");

            var gl = await _glRepo.GetPlayerLibraryCached((ulong)p.ID64, p.ID.ToString());

         
            Assert.IsTrue(gl.Count() > 0);
        }


    }
}
