namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGameSchema3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameSchemas", "HasAchievements", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameSchemas", "HasAchievements");
        }
    }
}
