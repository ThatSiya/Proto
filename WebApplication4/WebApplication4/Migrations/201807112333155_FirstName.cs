namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccessLevels", "Notes", c => c.String(maxLength: 50));
            AlterColumn("dbo.Orders", "OrderQty", c => c.Int(nullable: false));
            AlterColumn("dbo.UserAccessLevels", "UserAccessLevelDescr", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccessLevels", "UserAccessLevelDescr", c => c.String(maxLength: 50));
            AlterColumn("dbo.Orders", "OrderQty", c => c.Int());
            DropColumn("dbo.UserAccessLevels", "Notes");
        }
    }
}
