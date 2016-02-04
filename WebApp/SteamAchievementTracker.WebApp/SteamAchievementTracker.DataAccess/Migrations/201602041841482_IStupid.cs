namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IStupid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameSchemas", "LastSchemaUpdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.GameSchemas", "LastSchemaSUpdate");
            DropColumn("dbo.GameSchemas", "LastAchievementUpdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameSchemas", "LastAchievementUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GameSchemas", "LastSchemaSUpdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.GameSchemas", "LastSchemaUpdate");
        }
    }
}
