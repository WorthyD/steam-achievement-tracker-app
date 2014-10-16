using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Tests.Data
{
    [TestClass]
    public class Game
    {
        public DataAccess.Data.Game db = new DataAccess.Data.Game("SteamDB.db");

        [TestMethod]
        public void DAGameInsert()
        {
            IGame g = SteamAchievementTracker.DesignData.DummyClasses.Game.GetRandomGame();
            db.InsertItem(g);

            string title = g.Name;

            g = db.GetItem(new KeyValuePair<long, long>(g.SteamUserID, g.AppID));


            Assert.IsTrue(g.Name == title);
        }

        [TestMethod]
        public void DAGameUpdate()
        {
            IGame g = SteamAchievementTracker.DesignData.DummyClasses.Game.GetRandomGame();
            db.InsertItem(g);

            string title = g.Name;
            g = db.GetItem(new KeyValuePair<long, long>(g.SteamUserID, g.AppID));

            Assert.IsTrue(g.Name == title);
        }




        [TestMethod]
        public void DAGameUpdateAchievements()
        {
            int id = 1;
            InsertData(id);

            var g = db.GetItem(new KeyValuePair<long, long>(id, id));


            db.UpdateGameStats(g.StatsLink, 1, 1);

            g = db.GetItem(new KeyValuePair<long, long>(id, id));


            Assert.IsTrue(g.AchievementsEarned == 1);
        }


        private void InsertData(int id)
        {
            Model.Game g = new Model.Game();
            g.AchievementsEarned = 0;
            g.AppID = id;
            g.GameLink = "http://google.com";
            g.HoursPlayed = 1;
            g.LastUpdated = DateTime.Now;
            g.Icon = "http://google.com";
            g.Logo = "http://google.com";
            g.Name = "Game";
            g.RecentHours = 1;
            g.StatsLink = "http://google.com/" + id;
            g.SteamUserID = id;
            g.TotalAchievements = 0;
           

            db.InsertItem(g);
        }

    }




}
