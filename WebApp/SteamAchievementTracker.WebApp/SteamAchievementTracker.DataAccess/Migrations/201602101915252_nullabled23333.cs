namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabled23333 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameAchievements", "Description", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameAchievements", "Description");
        }
    }
}
