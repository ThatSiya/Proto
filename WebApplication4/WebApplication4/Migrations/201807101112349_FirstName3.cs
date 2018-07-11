namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstName3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FarmWorkers", "FarmID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderItemPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Fields", "FieldHectares", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderLines", "OrderLineTotalAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.Plantations", "RefugeSeedAmntUsed", c => c.Double(nullable: false));
            AlterColumn("dbo.Plantations", "RefugeAreaHectares", c => c.Double(nullable: false));
            AlterColumn("dbo.Plantations", "ExpectedYieldQnty", c => c.Double(nullable: false));
            AlterColumn("dbo.SiloHarvests", "SiloHarvestTonnesStored", c => c.Double(nullable: false));
            AlterColumn("dbo.Silos", "SiloCapacity", c => c.Double(nullable: false));
            AlterColumn("dbo.Silos", "SiloRentalFeePA", c => c.Double(nullable: false));
            AlterColumn("dbo.SiloHarvestSales", "SiloHarvestSaleTotalAmnt", c => c.Double(nullable: false));
            AlterColumn("dbo.SiloHarvestSales", "SiloHarvestSaleTotalQty", c => c.Double(nullable: false));
            AlterColumn("dbo.Sales", "SaleQty", c => c.Double(nullable: false));
            AlterColumn("dbo.Sales", "SaleAmnt", c => c.Double(nullable: false));
            AlterColumn("dbo.VehicleServices", "VehicleService_Cost", c => c.Double());
            CreateIndex("dbo.FarmWorkers", "FarmID");
            AddForeignKey("dbo.FarmWorkers", "FarmID", "dbo.Farms", "FarmID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FarmWorkers", "FarmID", "dbo.Farms");
            DropIndex("dbo.FarmWorkers", new[] { "FarmID" });
            AlterColumn("dbo.VehicleServices", "VehicleService_Cost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Sales", "SaleAmnt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Sales", "SaleQty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SiloHarvestSales", "SiloHarvestSaleTotalQty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SiloHarvestSales", "SiloHarvestSaleTotalAmnt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Silos", "SiloRentalFeePA", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Silos", "SiloCapacity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SiloHarvests", "SiloHarvestTonnesStored", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Plantations", "ExpectedYieldQnty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Plantations", "RefugeAreaHectares", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Plantations", "RefugeSeedAmntUsed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderLines", "OrderLineTotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Fields", "FieldHectares", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "OrderItemPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.FarmWorkers", "FarmID");
        }
    }
}
