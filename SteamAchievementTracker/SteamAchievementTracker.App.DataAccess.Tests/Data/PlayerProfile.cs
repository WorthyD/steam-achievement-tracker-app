using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Tests.Data
{
    [TestClass]
    public class PlayerProfile
    {
        public DataAccess.Data.PlayerProfile db = new DataAccess.Data.PlayerProfile("SteamDB.db");
        public long UserID = 76561198025095151;

        [TestMethod]
        public void GetProfileByUserID()
        {
            InsertData();
            var p = db.GetItem(UserID);
            Assert.IsTrue(p.ID64 == UserID);
        }

        [TestMethod]
        public void UpdateUser()
        {
            InsertData();
            var p = db.GetItem(UserID);
            string oldName = p.Name;
            p.Name = "D";
            db.UpdateItem(UserID, p);
            var p2 = db.GetItem(UserID);

            Assert.IsTrue(p2.Name != oldName);
        }



        private void InsertData()
        {
            Model.Profile p = new Model.Profile();
            p.ID64 = 76561198025095151;
            p.ID = "WorthyD";
            p.Name = "Daniel Worthy";
            p.ThumbURL = "http://www.gravatar.com/avatar/67b727175a880f13e6240c856764670e.png?s=50";
            p.LastUpdate = DateTime.Now;

            db.InsertItem(p);
        }

    }
}
