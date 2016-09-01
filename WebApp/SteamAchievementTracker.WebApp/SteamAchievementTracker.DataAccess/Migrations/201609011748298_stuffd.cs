namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuffd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameAchievements", "Description", c => c.String(maxLength: 350));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameAchievements", "Description", c => c.String(maxLength: 250));
        }
    }
}
