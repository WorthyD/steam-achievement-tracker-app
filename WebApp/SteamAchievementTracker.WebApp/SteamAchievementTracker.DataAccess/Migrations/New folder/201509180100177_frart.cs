namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerGamePlayerProfiles", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" }, "dbo.PlayerGames");
            DropForeignKey("dbo.PlayerGamePlayerProfiles", "PlayerProfile_PlayerID64", "dbo.PlayerProfiles");
            DropIndex("dbo.PlayerGamePlayerProfiles", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" });
            DropIndex("dbo.PlayerGamePlayerProfiles", new[] { "PlayerProfile_PlayerID64" });
            CreateIndex("dbo.PlayerGames", "PlayerID64");
            AddForeignKey("dbo.PlayerGames", "PlayerID64", "dbo.PlayerProfiles", "PlayerID64", cascadeDelete: true);
            DropTable("dbo.PlayerGamePlayerProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlayerGamePlayerProfiles",
                c => new
                    {
                        PlayerGame_PlayerID64 = c.Long(nullable: false),
                        PlayerGame_AppID = c.Int(nullable: false),
                        PlayerProfile_PlayerID64 = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerGame_PlayerID64, t.PlayerGame_AppID, t.PlayerProfile_PlayerID64 });
            
            DropForeignKey("dbo.PlayerGames", "PlayerID64", "dbo.PlayerProfiles");
            DropIndex("dbo.PlayerGames", new[] { "PlayerID64" });
            CreateIndex("dbo.PlayerGamePlayerProfiles", "PlayerProfile_PlayerID64");
            CreateIndex("dbo.PlayerGamePlayerProfiles", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" });
            AddForeignKey("dbo.PlayerGamePlayerProfiles", "PlayerProfile_PlayerID64", "dbo.PlayerProfiles", "PlayerID64", cascadeDelete: true);
            AddForeignKey("dbo.PlayerGamePlayerProfiles", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" }, "dbo.PlayerGames", new[] { "PlayerID64", "AppID" }, cascadeDelete: true);
        }
    }
}
