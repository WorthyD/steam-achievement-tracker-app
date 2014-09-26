using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace SteamAchievementTracker.App.DataAccess.Tests.Data
{
    [TestClass]
    public class RecentGames
    {
        public DataAccess.Data.PlayerRecentGames db = new DataAccess.Data.PlayerRecentGames();
        public RecentGames()
        {
            db.connectionString = "SteamDB.db";
        }

        [TestMethod]
        public void RecentGamesGetAll()
        {
            this.InsertData();
            //Test output
            var q = db.GetByUserID(100);

            Assert.IsTrue(q.Count() == 2);
        }

        [TestMethod]
        public void RecentGamesDelete()
        {
            this.InsertData();
            db.DeleteItem(100);
            var q = db.GetByUserID(100);

            Assert.IsTrue(q.Count() == 0);

        }

        private void InsertData()
        {
            SteamAchievementTracker.Model.RecentGame rg = new Model.RecentGame();
            rg.GameLink = "http://google.com";
            rg.ID64 = 100;

            db.InsertItem(rg);
            rg.GameLink = "http://google2.com";
            db.InsertItem(rg);
            rg.ID64 = 101;
            db.InsertItem(rg);


        }



    }
}
