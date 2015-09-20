namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frart3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerGameAchievements",
                c => new
                    {
                        PlayerID64 = c.Long(nullable: false),
                        AppID = c.Int(nullable: false),
                        AchievementID = c.String(nullable: false, maxLength: 250),
                        StatsURL = c.String(nullable: false, maxLength: 250),
                        IsUnlocked = c.Boolean(nullable: false),
                        AchievementIcon = c.String(nullable: false, maxLength: 250),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false, maxLength: 250),
                        UnlockTimestamp = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerID64, t.AppID, t.AchievementID })
                .ForeignKey("dbo.PlayerGames", t => new { t.PlayerID64, t.AppID }, cascadeDelete: true)
                .ForeignKey("dbo.PlayerProfiles", t => t.PlayerID64, cascadeDelete: true)
                .Index(t => new { t.PlayerID64, t.AppID });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerGameAchievements", "PlayerID64", "dbo.PlayerProfiles");
            DropForeignKey("dbo.PlayerGameAchievements", new[] { "PlayerID64", "AppID" }, "dbo.PlayerGames");
            DropIndex("dbo.PlayerGameAchievements", new[] { "PlayerID64", "AppID" });
            DropTable("dbo.PlayerGameAchievements");
        }
    }
}
