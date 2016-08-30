namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Avg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameSchemas", "AvgUnlock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameSchemas", "AvgUnlock");
        }
    }
}
