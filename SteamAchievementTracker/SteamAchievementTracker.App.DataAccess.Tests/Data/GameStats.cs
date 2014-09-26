using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Tests.Data
{
    [TestClass]
    public class GameStats
    {
        public DataAccess.Data.GameAchievement db = new DataAccess.Data.GameAchievement("SteamDB.db");
        public GameStats()
        {
            db.connectionString = "SteamDB.db";
        }

        [TestMethod]
        public void UpdateAchivementItem()
        {
            this.InsertData();
            var i = db.GetByStatsUrl("http://google.com");

            var one = i.FirstOrDefault();
            one.IsUnlocked = true;

            db.UpdateItem(new KeyValuePair<string, string>("http://google.com", "1"), one);
        }



        private void InsertData()
        {

            SteamAchievementTracker.Model.GameAchievement ga = new Model.GameAchievement();
            string dummyString = "http://google.com";
            ga.AchievementIcon = dummyString;
            ga.AchievementID = "1";
            ga.Description = dummyString;
            ga.IsUnlocked = true;
            ga.Name = dummyString;
            ga.StatsURL = dummyString;
            ga.UnlockTimestamp = "1111111";
            db.InsertItem(ga);

        }
    }
}
