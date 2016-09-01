namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PlayerGameAchievements");
            AlterColumn("dbo.PlayerGameAchievements", "ApiName", c => c.String(nullable: false, maxLength: 350));
            AddPrimaryKey("dbo.PlayerGameAchievements", new[] { "SteamId", "AppID", "ApiName" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PlayerGameAchievements");
            AlterColumn("dbo.PlayerGameAchievements", "ApiName", c => c.String(nullable: false, maxLength: 250));
            AddPrimaryKey("dbo.PlayerGameAchievements", new[] { "SteamId", "AppID", "ApiName" });
        }
    }
}
