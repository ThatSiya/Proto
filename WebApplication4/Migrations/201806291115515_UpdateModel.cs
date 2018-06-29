namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Silos", "SiloStatus", c => c.String());
            AddColumn("dbo.Vehicles", "VehName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Vehicles", "VehServiceIntervalUnit", c => c.String());
            AddColumn("dbo.VehicleTypes", "VehTypeImg", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Suppliers", "Address", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Suppliers", "Surburb", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Suppliers", "City", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Suppliers", "Country", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Suppliers", "Province", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.FarmWorkerTypes", "FarmWorkerTypeActiveStatus", c => c.String(nullable: false));
            DropColumn("dbo.Suppliers", "SupplierPhysAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "SupplierPhysAddress", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.FarmWorkerTypes", "FarmWorkerTypeActiveStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Suppliers", "Province");
            DropColumn("dbo.Suppliers", "Country");
            DropColumn("dbo.Suppliers", "City");
            DropColumn("dbo.Suppliers", "Surburb");
            DropColumn("dbo.Suppliers", "Address");
            DropColumn("dbo.VehicleTypes", "VehTypeImg");
            DropColumn("dbo.Vehicles", "VehServiceIntervalUnit");
            DropColumn("dbo.Vehicles", "VehName");
            DropColumn("dbo.Silos", "SiloStatus");
        }
    }
}
