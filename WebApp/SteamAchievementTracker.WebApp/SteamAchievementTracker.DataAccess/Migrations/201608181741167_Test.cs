namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameAchievements",
                c => new
                    {
                        AppId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 250),
                        DisplayName = c.String(nullable: false, maxLength: 250),
                        Hidden = c.Boolean(nullable: false),
                        Icon = c.String(nullable: false, maxLength: 250),
                        IconGray = c.String(nullable: false, maxLength: 250),
                        Percent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppId, t.Name })
                .ForeignKey("dbo.GameSchemas", t => t.AppId)
                .Index(t => t.AppId);
            
            CreateTable(
                "dbo.GameSchemas",
                c => new
                    {
                        AppId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        LastSchemaUpdate = c.DateTime(nullable: false),
                        HasAchievements = c.Boolean(nullable: false),
                        Img_Icon_Url = c.String(nullable: false, maxLength: 250),
                        Img_Logo_Url = c.String(nullable: false, maxLength: 250),
                        has_community_visible_stats = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AppId);
            
            CreateTable(
                "dbo.PlayerGames",
                c => new
                    {
                        SteamId = c.Long(nullable: false),
                        AppID = c.Long(nullable: false),
                        Playtime_Forever = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Playtime_2weeks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastUpdated = c.DateTime(nullable: false),
                        AchievementRefresh = c.DateTime(nullable: false),
                        RefreshAchievements = c.Boolean(nullable: false),
                        AchievementsEarned = c.Int(nullable: false),
                        AchievementsLocked = c.Int(nullable: false),
                        TotalAchievements = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SteamId, t.AppID })
                .ForeignKey("dbo.GameSchemas", t => t.AppID)
                .ForeignKey("dbo.PlayerProfiles", t => t.SteamId)
                .Index(t => t.SteamId)
                .Index(t => t.AppID);
            
            CreateTable(
                "dbo.PlayerGameAchievements",
                c => new
                    {
                        SteamId = c.Long(nullable: false),
                        AppID = c.Long(nullable: false),
                        ApiName = c.String(nullable: false, maxLength: 250),
                        Achieved = c.Boolean(nullable: false),
                        UnlockTimestamp = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.SteamId, t.AppID, t.ApiName })
                .ForeignKey("dbo.PlayerGames", t => new { t.SteamId, t.AppID })
                .ForeignKey("dbo.PlayerProfiles", t => t.SteamId)
                .Index(t => new { t.SteamId, t.AppID });
            
            CreateTable(
                "dbo.PlayerProfiles",
                c => new
                    {
                        SteamId = c.Long(nullable: false),
                        PersonaName = c.String(nullable: false, maxLength: 250),
                        RealName = c.String(nullable: false, maxLength: 250),
                        AvatarFull = c.String(nullable: false, maxLength: 250),
                        ProfileUrl = c.String(nullable: false, maxLength: 250),
                        LastUpdate = c.DateTime(nullable: false),
                        LibraryLastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SteamId);
            
            CreateTable(
                "dbo.ProfileRecentGames",
                c => new
                    {
                        SteamId = c.Long(nullable: false),
                        AppId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.SteamId, t.AppId })
                .ForeignKey("dbo.GameSchemas", t => t.AppId)
                .ForeignKey("dbo.PlayerProfiles", t => t.SteamId)
                .Index(t => t.SteamId)
                .Index(t => t.AppId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameAchievements", "AppId", "dbo.GameSchemas");
            DropForeignKey("dbo.PlayerGames", "SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", "SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", "AppId", "dbo.GameSchemas");
            DropForeignKey("dbo.PlayerGameAchievements", "SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.PlayerGameAchievements", new[] { "SteamId", "AppID" }, "dbo.PlayerGames");
            DropForeignKey("dbo.PlayerGames", "AppID", "dbo.GameSchemas");
            DropIndex("dbo.ProfileRecentGames", new[] { "AppId" });
            DropIndex("dbo.ProfileRecentGames", new[] { "SteamId" });
            DropIndex("dbo.PlayerGameAchievements", new[] { "SteamId", "AppID" });
            DropIndex("dbo.PlayerGames", new[] { "AppID" });
            DropIndex("dbo.PlayerGames", new[] { "SteamId" });
            DropIndex("dbo.GameAchievements", new[] { "AppId" });
            DropTable("dbo.ProfileRecentGames");
            DropTable("dbo.PlayerProfiles");
            DropTable("dbo.PlayerGameAchievements");
            DropTable("dbo.PlayerGames");
            DropTable("dbo.GameSchemas");
            DropTable("dbo.GameAchievements");
        }
    }
}
