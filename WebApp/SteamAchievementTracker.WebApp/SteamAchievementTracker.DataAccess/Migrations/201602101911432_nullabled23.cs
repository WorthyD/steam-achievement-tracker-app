namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabled23 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlayerGameAchievements", "UnlockTimestamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlayerGameAchievements", "UnlockTimestamp", c => c.DateTime(nullable: false));
        }
    }
}
