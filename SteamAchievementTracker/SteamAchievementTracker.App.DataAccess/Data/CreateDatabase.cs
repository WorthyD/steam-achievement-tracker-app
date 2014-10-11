using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Data
{
    public class CreateDatabase
    {
        public static void DestroyDatabase(SQLiteConnection db)
        {
            List<string> sql = new List<string>(){ "PlayerProfile",
                            "Game",
                            "GameAchievement"
                            ,"PlayerRecentGames"};

            foreach (var s in sql)
            {
                string query = string.Format("DROP TABLE [{0}];", s);
                using (var statement = db.Prepare(query))
                {
                    statement.Step();
                }
            }

 
        }

        public static void LoadDatabase(SQLiteConnection db)
        {

            string sql = @"CREATE TABLE IF NOT EXISTS  [PlayerProfile] (
                    [ID64] BIGINT  NOT NULL PRIMARY KEY,
                    [ID] VARCHAR(250)  NULL,
                    [Name] VARCHAR(250)  NULL,
                    [Thumbnail] VARCHAR(150)  NULL,
                    [LastUpdate] TIMESTAMP NULL
                );";

            using (var statement = db.Prepare(sql))
            {
                statement.Step();
            }
            var g = new Game("");
            sql = g.CreateTable();

            using (var statement = db.Prepare(sql))
            {
                statement.Step();
            }

            var sl = new GameAchievement("");
            sql = sl.CreateTable();

            using (var statement = db.Prepare(sql))
            {
                statement.Step();
            }

            var sl2 = new PlayerRecentGames();
            sql = sl2.CreateTable();

            using (var statement = db.Prepare(sql))
            {
                statement.Step();
            }



            // Turn on Foreign Key constraints
            sql = @"PRAGMA foreign_keys = ON";
            using (var statement = db.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}
