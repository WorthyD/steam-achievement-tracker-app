namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerGameAchievements", "PlayerProfile_SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", "PlayerProfile_SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.PlayerGames", "SteamId", "dbo.PlayerProfiles");
            DropPrimaryKey("dbo.PlayerProfiles");
            AlterColumn("dbo.PlayerProfiles", "SteamId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.PlayerProfiles", "SteamId");
            AddForeignKey("dbo.PlayerGameAchievements", "PlayerProfile_SteamId", "dbo.PlayerProfiles", "SteamId");
            AddForeignKey("dbo.ProfileRecentGames", "PlayerProfile_SteamId", "dbo.PlayerProfiles", "SteamId");
            AddForeignKey("dbo.PlayerGames", "SteamId", "dbo.PlayerProfiles", "SteamId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerGames", "SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.ProfileRecentGames", "PlayerProfile_SteamId", "dbo.PlayerProfiles");
            DropForeignKey("dbo.PlayerGameAchievements", "PlayerProfile_SteamId", "dbo.PlayerProfiles");
            DropPrimaryKey("dbo.PlayerProfiles");
            AlterColumn("dbo.PlayerProfiles", "SteamId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.PlayerProfiles", "SteamId");
            AddForeignKey("dbo.PlayerGames", "SteamId", "dbo.PlayerProfiles", "SteamId", cascadeDelete: true);
            AddForeignKey("dbo.ProfileRecentGames", "PlayerProfile_SteamId", "dbo.PlayerProfiles", "SteamId");
            AddForeignKey("dbo.PlayerGameAchievements", "PlayerProfile_SteamId", "dbo.PlayerProfiles", "SteamId");
        }
    }
}
