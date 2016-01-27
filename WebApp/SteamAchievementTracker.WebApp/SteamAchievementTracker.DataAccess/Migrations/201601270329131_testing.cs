namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerGames",
                c => new
                    {
                        SteamId = c.Long(nullable: false),
                        AppID = c.Int(nullable: false),
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
                        BeenProcessed = c.Boolean(nullable: false),
                        PercentComplete = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.SteamId, t.AppID })
                .ForeignKey("dbo.PlayerProfiles", t => t.SteamId, cascadeDelete: true)
                .Index(t => t.SteamId);
            
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
                        PlayerGame_SteamId = c.Long(),
                        PlayerGame_AppID = c.Int(),
                        PlayerProfile_SteamId = c.Long(),
                    })
                .PrimaryKey(t => new { t.PlayerID64, t.AppID, t.AchievementID })
                .ForeignKey("dbo.PlayerGames", t => new { t.PlayerGame_SteamId, t.PlayerGame_AppID })
                .ForeignKey("dbo.PlayerProfiles", t => t.PlayerProfile_SteamId)
                .Index(t => new { t.PlayerGame_SteamId, t.PlayerGame_AppID })
                .Index(t => t.PlayerProfile_SteamId);
            
            CreateTable(
                "dbo.PlayerProfiles",
                c => new
                    {
                        SteamId = c.Long(nullable: false, identity: true),
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
                        PlayerGame_AppID = c.Int(),
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
            DropForeignKey("dbo.PlayerGames", "SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", "PlayerProfile_SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", new[] { "PlayerGame_SteamId", "PlayerGame_AppID" }, "dbo.PlayerGames");
            DropForeignKey("dbo.PlayerGameAchievements", "PlayerProfile_SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.PlayerGameAchievements", new[] { "PlayerGame_SteamId", "PlayerGame_AppID" }, "dbo.PlayerGames");
            DropIndex("dbo.ProfileRecentGames", new[] { "PlayerProfile_SteamId" });
            DropIndex("dbo.ProfileRecentGames", new[] { "PlayerGame_SteamId", "PlayerGame_AppID" });
            DropIndex("dbo.PlayerGameAchievements", new[] { "PlayerProfile_SteamId" });
            DropIndex("dbo.PlayerGameAchievements", new[] { "PlayerGame_SteamId", "PlayerGame_AppID" });
            DropIndex("dbo.PlayerGames", new[] { "SteamId" });
            DropTable("dbo.ProfileRecentGames");
            DropTable("dbo.PlayerProfiles");
            DropTable("dbo.PlayerGameAchievements");
            DropTable("dbo.PlayerGames");
        }
    }
}
