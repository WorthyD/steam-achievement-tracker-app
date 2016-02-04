namespace SteamAchievementTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGameSchema2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameSchemas", "LastSchemaSUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameSchemas", "LastSchemaSUpdate");
        }
    }
}
