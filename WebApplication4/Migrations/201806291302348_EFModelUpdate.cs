namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EFModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FarmWorkers", "Address", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.FarmWorkers", "Surburb", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.FarmWorkers", "City", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.FarmWorkers", "Country", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.FarmWorkers", "Province", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.FarmWorkers", "FarmWorkerPhysicalAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FarmWorkers", "FarmWorkerPhysicalAddress", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.FarmWorkers", "Province");
            DropColumn("dbo.FarmWorkers", "Country");
            DropColumn("dbo.FarmWorkers", "City");
            DropColumn("dbo.FarmWorkers", "Surburb");
            DropColumn("dbo.FarmWorkers", "Address");
        }
    }
}
