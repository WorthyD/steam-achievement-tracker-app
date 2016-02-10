namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabled233333443434 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameAchievements", "Description", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameAchievements", "Description", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
