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

         
            //File.Copy

          
            


            Debug.WriteLine(result);
            Assert.IsTrue(p.ID == "WorthyD");
        }

    }
}
