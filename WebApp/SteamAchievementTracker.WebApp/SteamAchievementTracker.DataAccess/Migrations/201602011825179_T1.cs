namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PlayerGames", "BeenProcessed");
            DropColumn("dbo.PlayerGames", "PercentComplete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlayerGames", "PercentComplete", c => c.Double(nullable: false));
            AddColumn("dbo.PlayerGames", "BeenProcessed", c => c.Boolean(nullable: false));
        }
    }
}
