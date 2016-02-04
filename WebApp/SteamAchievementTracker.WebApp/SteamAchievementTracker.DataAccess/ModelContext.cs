using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SteamAchievementTracker.DataAccess {
    public class ModelContext : DbContext, IDisposable  {
        public static string Connection {
            get {

                return "DefaultConnection";
            }
        }
        public ModelContext() : base("DefaultConnection") { }


        public DbSet<Models.PlayerGame> PlayerGames { get; set; }
        //public DbSet<Models.PlayerGameTags> PlayerGameTags { get; set; }
        public DbSet<Models.PlayerProfile> PlayerProfiles { get; set; }
        public DbSet<Models.ProfileRecentGame> ProfileRecentGames { get; set; }

        public DbSet<Models.PlayerGameAchievements> PlayerGameAchievements { get; set; }
        public DbSet<Models.GameAchievement> GameAchievements { get; set; }
        public DbSet<Models.GameSchema> GameSchemas { get; set; }


    }
}
