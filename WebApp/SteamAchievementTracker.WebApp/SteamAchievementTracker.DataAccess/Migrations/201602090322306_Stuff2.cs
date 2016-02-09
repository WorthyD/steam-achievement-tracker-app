namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stuff2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlayerGameAchievements", "UnlockTimestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlayerGameAchievements", "UnlockTimestamp", c => c.String(nullable: false));
        }
    }
}
