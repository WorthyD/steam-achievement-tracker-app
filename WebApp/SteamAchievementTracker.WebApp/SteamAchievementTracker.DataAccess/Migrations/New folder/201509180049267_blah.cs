namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blah : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerGames", "PlayerID64", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", "ID64", "dbo.PlayerProfiles");
            DropIndex("dbo.PlayerGames", new[] { "PlayerID64" });
            DropIndex("dbo.ProfileRecentGames", new[] { "ID64" });
            CreateTable(
                "dbo.PlayerGamePlayerProfiles",
                c => new
                    {
                        PlayerGame_PlayerID64 = c.Long(nullable: false),
                        PlayerGame_AppID = c.Int(nullable: false),
                        PlayerProfile_PlayerID64 = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerGame_PlayerID64, t.PlayerGame_AppID, t.PlayerProfile_PlayerID64 })
                .ForeignKey("dbo.PlayerGames", t => new { t.PlayerGame_PlayerID64, t.PlayerGame_AppID }, cascadeDelete: true)
                .ForeignKey("dbo.PlayerProfiles", t => t.PlayerProfile_PlayerID64, cascadeDelete: true)
                .Index(t => new { t.PlayerGame_PlayerID64, t.PlayerGame_AppID })
                .Index(t => t.PlayerProfile_PlayerID64);
            
            AddColumn("dbo.ProfileRecentGames", "PlayerGame_PlayerID64", c => c.Long());
            AddColumn("dbo.ProfileRecentGames", "PlayerGame_AppID", c => c.Int());
            AddColumn("dbo.ProfileRecentGames", "PlayerProfile_PlayerID64", c => c.Long());
            CreateIndex("dbo.ProfileRecentGames", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" });
            CreateIndex("dbo.ProfileRecentGames", "PlayerProfile_PlayerID64");
            AddForeignKey("dbo.ProfileRecentGames", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" }, "dbo.PlayerGames", new[] { "PlayerID64", "AppID" });
            AddForeignKey("dbo.ProfileRecentGames", "PlayerProfile_PlayerID64", "dbo.PlayerProfiles", "PlayerID64");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileRecentGames", "PlayerProfile_PlayerID64", "dbo.PlayerProfiles");
            DropForeignKey("dbo.PlayerGamePlayerProfiles", "PlayerProfile_PlayerID64", "dbo.PlayerProfiles");
            DropForeignKey("dbo.PlayerGamePlayerProfiles", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" }, "dbo.PlayerGames");
            DropForeignKey("dbo.ProfileRecentGames", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" }, "dbo.PlayerGames");
            DropIndex("dbo.PlayerGamePlayerProfiles", new[] { "PlayerProfile_PlayerID64" });
            DropIndex("dbo.PlayerGamePlayerProfiles", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" });
            DropIndex("dbo.ProfileRecentGames", new[] { "PlayerProfile_PlayerID64" });
            DropIndex("dbo.ProfileRecentGames", new[] { "PlayerGame_PlayerID64", "PlayerGame_AppID" });
            DropColumn("dbo.ProfileRecentGames", "PlayerProfile_PlayerID64");
            DropColumn("dbo.ProfileRecentGames", "PlayerGame_AppID");
            DropColumn("dbo.ProfileRecentGames", "PlayerGame_PlayerID64");
            DropTable("dbo.PlayerGamePlayerProfiles");
            CreateIndex("dbo.ProfileRecentGames", "ID64");
            CreateIndex("dbo.PlayerGames", "PlayerID64");
            AddForeignKey("dbo.ProfileRecentGames", "ID64", "dbo.PlayerProfiles", "PlayerID64", cascadeDelete: true);
            AddForeignKey("dbo.PlayerGames", "PlayerID64", "dbo.PlayerProfiles", "PlayerID64", cascadeDelete: true);
        }
    }
}
