using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Tests.Tasks {
    [TestClass]
    public class TaskTester {
        [TestMethod]
        public async Task TestAchievementTask() {
            var p = new SteamAchievementTracker.AchievementRefresh.AchievementRefreshTask(5, 24);
            //76561198025095151


            await p.Run(76561198025095151, "WorthyD", null);
            var result = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

            Debug.WriteLine(result);
            Debug.WriteLine("Complete");

        }
    }
}
