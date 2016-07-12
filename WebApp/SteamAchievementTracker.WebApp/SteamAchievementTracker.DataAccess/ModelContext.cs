using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SteamAchievementTracker.DataAccess {
    public class ModelContext : DbContext, IDisposable  {
        public static string Connection {
            get {

                return "DefaultConnection";
            }
        }
        public ModelContext() : base("DefaultConnection") {
            Database.SetInitializer<ModelContext>(null);
        }


        public DbSet<Models.PlayerGame> PlayerGames { get; set; }
        //public DbSet<Models.PlayerGameTags> PlayerGameTags { get; set; }
        public DbSet<Models.PlayerProfile> PlayerProfiles { get; set; }
        public DbSet<Models.ProfileRecentGame> ProfileRecentGames { get; set; }

        public DbSet<Models.PlayerGameAchievement> PlayerGameAchievements { get; set; }
        public DbSet<Models.GameAchievement> GameAchievements { get; set; }
        public DbSet<Models.GameSchema> GameSchemas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<aspnet_UsersInRoles>().HasMany(i => i.Users).WithRequired().WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
