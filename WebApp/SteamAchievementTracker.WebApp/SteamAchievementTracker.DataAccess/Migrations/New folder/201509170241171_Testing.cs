namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerGames", "PlayerID64", "dbo.PlayerProfiles");
            DropIndex("dbo.PlayerGames", new[] { "PlayerID64" });
            DropTable("dbo.PlayerProfiles");
            DropTable("dbo.PlayerGames");
        }
    }
}
