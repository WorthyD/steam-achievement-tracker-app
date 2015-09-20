namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frart3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerGames",
                c => new
                    {
                        PlayerID64 = c.Long(nullable: false),
                        AppID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        StatsLink = c.String(nullable: false),
                        GameLink = c.String(nullable: false, maxLength: 250),
                        Logo = c.String(nullable: false, maxLength: 250),
                        Icon = c.String(nullable: false, maxLength: 250),
                        HoursPlayed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecentHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastUpdated = c.DateTime(nullable: false),
                        AchievementRefresh = c.DateTime(nullable: false),
                        RefreshAchievements = c.Boolean(nullable: false),
                        AchievementsEarned = c.Int(nullable: false),
                        AchievementsLocked = c.Int(nullable: false),
                        TotalAchievements = c.Int(nullable: false),
                        HasAchievements = c.Boolean(nullable: false),
                        BeenProcessed = c.Boolean(nullable: false),
                        PercentComplete = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerID64, t.AppID })
                .ForeignKey("dbo.PlayerProfiles", t => t.PlayerID64, cascadeDelete: true)
                .Index(t => t.PlayerID64);
            
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
                .ForeignKey("dbo.PlayerGames", t => new { t.PlayerID64, t.AppID })
                .ForeignKey("dbo.PlayerProfiles", t => t.PlayerID64)
                .Index(t => new { t.PlayerID64, t.AppID });
            
            CreateTable(
                "dbo.PlayerProfiles",
                c => new
                    {
                        PlayerID64 = c.Long(nullable: false, identity: true),
                        CustomUrl = c.String(nullable: false, maxLength: 250),
                        Name = c.String(nullable: false, maxLength: 250),
                        ThumbURL = c.String(nullable: false, maxLength: 250),
                        LastUpdate = c.DateTime(nullable: false),
                        LibraryLastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID64);
            
            CreateTable(
                "dbo.ProfileRecentGames",
                c => new
                    {
                        ID64 = c.Long(nullable: false),
                        AppID = c.Int(nullable: false),
                        PlayerGame_PlayerID64 = c.Long(),
                        PlayerGame_AppID = c.Int(),
                        PlayerProfile_PlayerID64 = c.Long(),
                    })
                .PrimaryKey(t => new { t.ID64, t.AppID })
                .ForeignKey("dbo.PlayerGames", t => new { t.PlayerGame_PlayerID64, t.PlayerGame_AppID })
                .ForeignKey("dbo.PlayerProfiles", t => t.PlayerProfile_PlayerID64)
                .Index(t => new { t.PlayerGame_PlayerID64, t.PlayerGame_AppID })
                .Index(t => t.PlayerProfile_PlayerID64);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerGames", "PlayerID64", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", "PlayerProfile_PlayerID64", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" }, "dbo.PlayerGames");
            DropForeignKey("dbo.PlayerGameAchievements", "PlayerID64", "dbo.PlayerProfiles");
            DropForeignKey("dbo.PlayerGameAchievements", new[] { "PlayerID64", "AppID" }, "dbo.PlayerGames");
            DropIndex("dbo.ProfileRecentGames", new[] { "PlayerProfile_PlayerID64" });
            DropIndex("dbo.ProfileRecentGames", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" });
            DropIndex("dbo.PlayerGameAchievements", new[] { "PlayerID64", "AppID" });
            DropIndex("dbo.PlayerGames", new[] { "PlayerID64" });
            DropTable("dbo.ProfileRecentGames");
            DropTable("dbo.PlayerProfiles");
            DropTable("dbo.PlayerGameAchievements");
            DropTable("dbo.PlayerGames");
        }
    }
}
