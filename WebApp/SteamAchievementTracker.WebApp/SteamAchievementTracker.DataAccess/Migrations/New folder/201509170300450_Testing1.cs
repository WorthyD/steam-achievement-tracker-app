namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileRecentGames",
                c => new
                    {
                        ID64 = c.Long(nullable: false),
                        AppID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID64, t.AppID })
                .ForeignKey("dbo.PlayerProfiles", t => t.ID64, cascadeDelete: true)
                .Index(t => t.ID64);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileRecentGames", "ID64", "dbo.PlayerProfiles");
            DropIndex("dbo.ProfileRecentGames", new[] { "ID64" });
            DropTable("dbo.ProfileRecentGames");
        }
    }
}
