namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameAchievements",
                c => new
                    {
                        AppId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
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
                    })
                .PrimaryKey(t => t.AppId);
            
            CreateTable(
                "dbo.PlayerGameAchievements",
                c => new
                    {
                        SteamId = c.Long(nullable: false),
                        AppID = c.Long(nullable: false),
                        ApiName = c.String(nullable: false, maxLength: 250),
                        Achieved = c.Boolean(nullable: false),
                        UnlockTimestamp = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.SteamId, t.AppID, t.ApiName })
                .ForeignKey("dbo.PlayerProfiles", t => t.SteamId)
                .ForeignKey("dbo.PlayerGames", t => new { t.SteamId, t.AppID })
                .Index(t => t.SteamId)
                .Index(t => new { t.SteamId, t.AppID });
            
            CreateTable(
                "dbo.PlayerGames",
                c => new
                    {
                        SteamId = c.Long(nullable: false),
                        AppID = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Playtime_Forever = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Playtime_2weeks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Img_Icon_Url = c.String(nullable: false, maxLength: 250),
                        Img_Logo_Url = c.String(nullable: false, maxLength: 250),
                        has_community_visible_stats = c.Boolean(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        AchievementRefresh = c.DateTime(nullable: false),
                        RefreshAchievements = c.Boolean(nullable: false),
                        AchievementsEarned = c.Int(nullable: false),
                        AchievementsLocked = c.Int(nullable: false),
                        TotalAchievements = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SteamId, t.AppID })
                .ForeignKey("dbo.PlayerProfiles", t => t.SteamId)
                .Index(t => t.SteamId);
            
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
                        ID64 = c.Long(nullable: false),
                        AppID = c.Int(nullable: false),
                        PlayerGame_SteamId = c.Long(),
                        PlayerGame_AppID = c.Long(),
                        PlayerProfile_SteamId = c.Long(),
                    })
                .PrimaryKey(t => new { t.ID64, t.AppID })
                .ForeignKey("dbo.PlayerGames", t => new { t.PlayerGame_SteamId, t.PlayerGame_AppID })
                .ForeignKey("dbo.PlayerProfiles", t => t.PlayerProfile_SteamId)
                .Index(t => new { t.PlayerGame_SteamId, t.PlayerGame_AppID })
                .Index(t => t.PlayerProfile_SteamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerGameAchievements", new[] { "SteamId", "AppID" }, "dbo.PlayerGames");
            DropForeignKey("dbo.PlayerGames", "SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", "PlayerProfile_SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", new[] { "PlayerGame_SteamId", "PlayerGame_AppID" }, "dbo.PlayerGames");
            DropForeignKey("dbo.PlayerGameAchievements", "SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.GameAchievements", "AppId", "dbo.GameSchemas");
            DropIndex("dbo.ProfileRecentGames", new[] { "PlayerProfile_SteamId" });
            DropIndex("dbo.ProfileRecentGames", new[] { "PlayerGame_SteamId", "PlayerGame_AppID" });
            DropIndex("dbo.PlayerGames", new[] { "SteamId" });
            DropIndex("dbo.PlayerGameAchievements", new[] { "SteamId", "AppID" });
            DropIndex("dbo.PlayerGameAchievements", new[] { "SteamId" });
            DropIndex("dbo.GameAchievements", new[] { "AppId" });
            DropTable("dbo.ProfileRecentGames");
            DropTable("dbo.PlayerProfiles");
            DropTable("dbo.PlayerGames");
            DropTable("dbo.PlayerGameAchievements");
            DropTable("dbo.GameSchemas");
            DropTable("dbo.GameAchievements");
        }
    }
}
