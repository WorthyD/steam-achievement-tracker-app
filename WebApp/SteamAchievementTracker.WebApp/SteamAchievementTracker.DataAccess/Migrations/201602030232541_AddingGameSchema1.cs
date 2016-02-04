namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGameSchema1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameAchievements",
                c => new
                    {
                        AppId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        DisplayName = c.String(nullable: false, maxLength: 250),
                        Hidden = c.Boolean(nullable: false),
                        Icon = c.String(nullable: false, maxLength: 250),
                        IconGray = c.String(nullable: false, maxLength: 250),
                        Percent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppId, t.Name })
                .ForeignKey("dbo.GameSchemas", t => t.AppId, cascadeDelete: true)
                .Index(t => t.AppId);
            
            CreateTable(
                "dbo.GameSchemas",
                c => new
                    {
                        AppId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        LastAchievementUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AppId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameAchievements", "AppId", "dbo.GameSchemas");
            DropIndex("dbo.GameAchievements", new[] { "AppId" });
            DropTable("dbo.GameSchemas");
            DropTable("dbo.GameAchievements");
        }
    }
}
