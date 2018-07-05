namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstName1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AttendenceSheets", "FarmWorkerNum", "dbo.FarmWorkers");
            DropForeignKey("dbo.FarmWorkers", "FarmWorkerTypeID", "dbo.FarmWorkerTypes");
            DropForeignKey("dbo.FarmWorkers", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.FarmWorkers", "TitleID", "dbo.Titles");
            DropForeignKey("dbo.AttendenceSheets", "UserID", "dbo.Users");
            DropForeignKey("dbo.Audits", "AuditTypeID", "dbo.AuditTypes");
            DropForeignKey("dbo.Audits", "UserID", "dbo.Users");
            DropForeignKey("dbo.Lands", "FarmID", "dbo.Farms");
            DropForeignKey("dbo.FieldBiologicalDisasters", "BioDisasterID", "dbo.BiologicalDisasters");
            DropForeignKey("dbo.FieldBiologicalDisasters", "FieldID", "dbo.Fields");
            DropForeignKey("dbo.FieldNaturalDisasters", "FieldID", "dbo.Fields");
            DropForeignKey("dbo.FieldNaturalDisasters", "NatDisasterID", "dbo.NaturalDisasters");
            DropForeignKey("dbo.Fields", "FieldStatID", "dbo.FieldStatus");
            DropForeignKey("dbo.FieldTreatments", "FieldID", "dbo.Fields");
            DropForeignKey("dbo.FieldTreatments", "TreatmentID", "dbo.Treatments");
            DropForeignKey("dbo.InventoryTreatments", "InventoryID", "dbo.Inventories");
            DropForeignKey("dbo.Inventories", "InvTypeID", "dbo.InventoryTypes");
            DropForeignKey("dbo.OrderLines", "InventoryID", "dbo.Inventories");
            DropForeignKey("dbo.OrderLines", "OrderNum", "dbo.Orders");
            DropForeignKey("dbo.InventoryTreatments", "TreatmentID", "dbo.Treatments");
            DropForeignKey("dbo.Fields", "LandID", "dbo.Lands");
            DropForeignKey("dbo.Plantations", "CropCycleID", "dbo.CropCycles");
            DropForeignKey("dbo.Plantations", "CropTypeID", "dbo.CropTypes");
            DropForeignKey("dbo.Plantations", "FieldID", "dbo.Fields");
            DropForeignKey("dbo.Plantations", "FieldStageID", "dbo.FieldStages");
            DropForeignKey("dbo.SiloHarvests", "PlantationID", "dbo.Plantations");
            DropForeignKey("dbo.SiloHarvests", "SiloID", "dbo.Silos");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.SiloHarvestSales", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.SiloHarvestSales", "SiloHarvestID", "dbo.SiloHarvests");
            DropForeignKey("dbo.RainfallRecords", "LandID", "dbo.Lands");
            DropForeignKey("dbo.Orders", "FarmID", "dbo.Farms");
            DropForeignKey("dbo.Provinces", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Farms", "ProvinceID", "dbo.Provinces");
            DropForeignKey("dbo.Vehicles", "FarmID", "dbo.Farms");
            DropForeignKey("dbo.Vehicles", "VehMakeID", "dbo.VehicleMakes");
            DropForeignKey("dbo.VehicleServices", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Logs", "UserAccessLevelID", "dbo.UserAccessLevels");
            DropForeignKey("dbo.Users", "UserAccessLevelID", "dbo.UserAccessLevels");
            DropForeignKey("dbo.AspNetUsers", "User_UserID", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "User_UserID" });
            DropIndex("dbo.Users", new[] { "UserAccessLevelID" });
            DropIndex("dbo.AttendenceSheets", new[] { "FarmWorkerNum" });
            DropIndex("dbo.AttendenceSheets", new[] { "UserID" });
            DropIndex("dbo.FarmWorkers", new[] { "TitleID" });
            DropIndex("dbo.FarmWorkers", new[] { "GenderID" });
            DropIndex("dbo.FarmWorkers", new[] { "FarmWorkerTypeID" });
            DropIndex("dbo.Audits", new[] { "UserID" });
            DropIndex("dbo.Audits", new[] { "AuditTypeID" });
            DropIndex("dbo.Orders", new[] { "SupplierID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Orders", new[] { "FarmID" });
            DropIndex("dbo.Orders", new[] { "OrderStatusID" });
            DropIndex("dbo.Farms", new[] { "ProvinceID" });
            DropIndex("dbo.Lands", new[] { "FarmID" });
            DropIndex("dbo.Fields", new[] { "FieldStatID" });
            DropIndex("dbo.Fields", new[] { "LandID" });
            DropIndex("dbo.FieldBiologicalDisasters", new[] { "FieldID" });
            DropIndex("dbo.FieldBiologicalDisasters", new[] { "BioDisasterID" });
            DropIndex("dbo.FieldNaturalDisasters", new[] { "FieldID" });
            DropIndex("dbo.FieldNaturalDisasters", new[] { "NatDisasterID" });
            DropIndex("dbo.FieldTreatments", new[] { "FieldID" });
            DropIndex("dbo.FieldTreatments", new[] { "TreatmentID" });
            DropIndex("dbo.InventoryTreatments", new[] { "TreatmentID" });
            DropIndex("dbo.InventoryTreatments", new[] { "InventoryID" });
            DropIndex("dbo.Inventories", new[] { "InvTypeID" });
            DropIndex("dbo.OrderLines", new[] { "OrderNum" });
            DropIndex("dbo.OrderLines", new[] { "InventoryID" });
            DropIndex("dbo.Plantations", new[] { "FieldID" });
            DropIndex("dbo.Plantations", new[] { "CropTypeID" });
            DropIndex("dbo.Plantations", new[] { "CropCycleID" });
            DropIndex("dbo.Plantations", new[] { "FieldStageID" });
            DropIndex("dbo.SiloHarvests", new[] { "SiloID" });
            DropIndex("dbo.SiloHarvests", new[] { "PlantationID" });
            DropIndex("dbo.SiloHarvestSales", new[] { "SiloHarvestID" });
            DropIndex("dbo.SiloHarvestSales", new[] { "SaleID" });
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropIndex("dbo.RainfallRecords", new[] { "LandID" });
            DropIndex("dbo.Provinces", new[] { "CountryID" });
            DropIndex("dbo.Vehicles", new[] { "FarmID" });
            DropIndex("dbo.Vehicles", new[] { "VehTypeID" });
            DropIndex("dbo.Vehicles", new[] { "VehMakeID" });
            DropIndex("dbo.VehicleServices", new[] { "VehicleID" });
            DropIndex("dbo.Logs", new[] { "UserAccessLevelID" });
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "User_UserID");
            DropTable("dbo.Users");
            DropTable("dbo.AttendenceSheets");
            DropTable("dbo.FarmWorkers");
            DropTable("dbo.FarmWorkerTypes");
            DropTable("dbo.Genders");
            DropTable("dbo.Titles");
            DropTable("dbo.Audits");
            DropTable("dbo.AuditTypes");
            DropTable("dbo.Orders");
            DropTable("dbo.Farms");
            DropTable("dbo.Lands");
            DropTable("dbo.Fields");
            DropTable("dbo.FieldBiologicalDisasters");
            DropTable("dbo.BiologicalDisasters");
            DropTable("dbo.FieldNaturalDisasters");
            DropTable("dbo.NaturalDisasters");
            DropTable("dbo.FieldStatus");
            DropTable("dbo.FieldTreatments");
            DropTable("dbo.Treatments");
            DropTable("dbo.InventoryTreatments");
            DropTable("dbo.Inventories");
            DropTable("dbo.InventoryTypes");
            DropTable("dbo.OrderLines");
            DropTable("dbo.Plantations");
            DropTable("dbo.CropCycles");
            DropTable("dbo.CropTypes");
            DropTable("dbo.FieldStages");
            DropTable("dbo.SiloHarvests");
            DropTable("dbo.Silos");
            DropTable("dbo.SiloHarvestSales");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
            DropTable("dbo.RainfallRecords");
            DropTable("dbo.Provinces");
            DropTable("dbo.Countries");
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleMakes");
            DropTable("dbo.VehicleServices");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Suppliers");
            DropTable("dbo.UserAccessLevels");
            DropTable("dbo.Logs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        LogInTimeStamp = c.DateTime(nullable: false),
                        LogOutTimeStamp = c.DateTime(nullable: false),
                        UserAccessLevelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogID);
            
            CreateTable(
                "dbo.UserAccessLevels",
                c => new
                    {
                        UserAccessLevelID = c.Int(nullable: false, identity: true),
                        UserAccessLevelDescr = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserAccessLevelID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false, maxLength: 50),
                        SupplierPhysAddress = c.String(nullable: false, maxLength: 10),
                        SupplierEmailAddress = c.String(nullable: false, maxLength: 50),
                        SupplierPhoneNum = c.String(nullable: false, maxLength: 10),
                        SupplierCellNum = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusID = c.Int(nullable: false, identity: true),
                        OrderStatusDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehTypeID = c.Int(nullable: false, identity: true),
                        VehTypeDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VehTypeID);
            
            CreateTable(
                "dbo.VehicleServices",
                c => new
                    {
                        VehicleServiceID = c.Int(nullable: false, identity: true),
                        VehicleService_Date = c.DateTime(nullable: false),
                        VehicleService_Cost = c.Decimal(precision: 18, scale: 2),
                        VehicleService_Mileage = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleServiceID);
            
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        VehMakeID = c.Int(nullable: false, identity: true),
                        VehMakeDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VehMakeID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        VehYear = c.String(nullable: false),
                        VehModel = c.String(nullable: false, maxLength: 100),
                        VehEngineNum = c.String(nullable: false, maxLength: 100),
                        VehVinNum = c.String(nullable: false, maxLength: 100),
                        VehRegNum = c.String(nullable: false, maxLength: 100),
                        VehLicenseNum = c.String(nullable: false, maxLength: 100),
                        VehExpDate = c.DateTime(),
                        VehCurrMileage = c.Int(nullable: false),
                        VehServiceInterval = c.String(nullable: false),
                        VehNextService = c.DateTime(nullable: false),
                        FarmID = c.Int(nullable: false),
                        VehTypeID = c.Int(nullable: false),
                        VehMakeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceID = c.Int(nullable: false, identity: true),
                        ProvinceDescr = c.String(nullable: false, maxLength: 50),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceID);
            
            CreateTable(
                "dbo.RainfallRecords",
                c => new
                    {
                        RainFallRecID = c.Int(nullable: false, identity: true),
                        RecordDate = c.DateTime(nullable: false),
                        RecordMeasurement = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RainFallRecID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerFName = c.String(nullable: false, maxLength: 50),
                        CustomerLName = c.String(nullable: false, maxLength: 50),
                        CustomerContactNum = c.String(nullable: false, maxLength: 10),
                        ContactPersonalEmailAddress = c.String(nullable: false, maxLength: 50),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        CompanyPhysAddress = c.String(nullable: false, maxLength: 100),
                        CompanyTelNum = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false),
                        SaleQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID);
            
            CreateTable(
                "dbo.SiloHarvestSales",
                c => new
                    {
                        SiloHarvestID = c.Int(nullable: false),
                        SaleID = c.Int(nullable: false),
                        SiloHarvestSaleTotalAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SiloHarvestSaleTotalQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.SiloHarvestID, t.SaleID });
            
            CreateTable(
                "dbo.Silos",
                c => new
                    {
                        SiloID = c.Int(nullable: false, identity: true),
                        SiloDescr = c.String(nullable: false, maxLength: 50),
                        SiloCapacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SiloRentalFeePA = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SiloID);
            
            CreateTable(
                "dbo.SiloHarvests",
                c => new
                    {
                        SiloHarvestID = c.Int(nullable: false, identity: true),
                        SiloHarvestStoreStartDate = c.DateTime(),
                        SiloHarvestStoreEndDate = c.DateTime(),
                        SiloHarvestTonnesStored = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SiloID = c.Int(nullable: false),
                        PlantationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SiloHarvestID);
            
            CreateTable(
                "dbo.FieldStages",
                c => new
                    {
                        FieldStageID = c.Int(nullable: false, identity: true),
                        FieldStageDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FieldStageID);
            
            CreateTable(
                "dbo.CropTypes",
                c => new
                    {
                        CropTypeID = c.Int(nullable: false, identity: true),
                        CropTypeDescr = c.String(nullable: false, maxLength: 50),
                        MaturityDays = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CropTypeID);
            
            CreateTable(
                "dbo.CropCycles",
                c => new
                    {
                        CropCycleID = c.Int(nullable: false, identity: true),
                        CropCycleStartDate = c.DateTime(nullable: false),
                        CropCycleEndDate = c.DateTime(nullable: false),
                        CropCycleDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CropCycleID);
            
            CreateTable(
                "dbo.Plantations",
                c => new
                    {
                        PlantationID = c.Int(nullable: false, identity: true),
                        FieldID = c.Int(nullable: false),
                        CropTypeID = c.Int(nullable: false),
                        CropCycleID = c.Int(nullable: false),
                        FieldStageID = c.Int(nullable: false),
                        DatePlanted = c.DateTime(nullable: false),
                        RefugeSeedAmntUsed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RefugeSeedUnit = c.String(nullable: false, maxLength: 50),
                        RefugeAreaHectares = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpectedYieldQnty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpectedYieldUnit = c.String(nullable: false, maxLength: 50),
                        DateHarvested = c.DateTime(nullable: false),
                        PlantationStatus = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PlantationID);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        OrderNum = c.Int(nullable: false),
                        InventoryID = c.Int(nullable: false),
                        OrderLineTotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderLineTotalQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderNum, t.InventoryID });
            
            CreateTable(
                "dbo.InventoryTypes",
                c => new
                    {
                        InvTypeID = c.Int(nullable: false, identity: true),
                        InvTypeDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.InvTypeID);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryID = c.Int(nullable: false, identity: true),
                        InvDescr = c.String(nullable: false, maxLength: 100),
                        InvQty = c.Int(nullable: false),
                        InvDatePurchased = c.DateTime(nullable: false),
                        InvCode = c.String(nullable: false),
                        InvSIUnit = c.String(nullable: false, maxLength: 50),
                        InvTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryID);
            
            CreateTable(
                "dbo.InventoryTreatments",
                c => new
                    {
                        TreatmentID = c.Int(nullable: false),
                        InventoryID = c.Int(nullable: false),
                        TreatmentQnty = c.Int(nullable: false),
                        TreatmentUnit = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.TreatmentID, t.InventoryID });
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatmentID = c.Int(nullable: false, identity: true),
                        TreatmentDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TreatmentID);
            
            CreateTable(
                "dbo.FieldTreatments",
                c => new
                    {
                        FieldID = c.Int(nullable: false),
                        TreatmentID = c.Int(nullable: false),
                        TreatmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.FieldID, t.TreatmentID });
            
            CreateTable(
                "dbo.FieldStatus",
                c => new
                    {
                        FieldStatID = c.Int(nullable: false, identity: true),
                        FieldStatDescr = c.String(nullable: false, maxLength: 50),
                        StatPreConditions = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FieldStatID);
            
            CreateTable(
                "dbo.NaturalDisasters",
                c => new
                    {
                        NatDisasterID = c.Int(nullable: false, identity: true),
                        NatDisasterDescr = c.String(nullable: false, maxLength: 50),
                        NatDisasterPrecautions = c.String(nullable: false, maxLength: 50),
                        NatDisasterPotentialEffects = c.String(nullable: false, maxLength: 100),
                        NatDisasterSigns = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.NatDisasterID);
            
            CreateTable(
                "dbo.FieldNaturalDisasters",
                c => new
                    {
                        FieldID = c.Int(nullable: false),
                        NatDisasterID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.FieldID, t.NatDisasterID });
            
            CreateTable(
                "dbo.BiologicalDisasters",
                c => new
                    {
                        BioDisasterID = c.Int(nullable: false, identity: true),
                        BioDisasterDescr = c.String(nullable: false, maxLength: 50),
                        BioDisasterNotes = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.BioDisasterID);
            
            CreateTable(
                "dbo.FieldBiologicalDisasters",
                c => new
                    {
                        FieldID = c.Int(nullable: false),
                        BioDisasterID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.FieldID, t.BioDisasterID });
            
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        FieldID = c.Int(nullable: false, identity: true),
                        FieldName = c.String(nullable: false, maxLength: 20),
                        FieldHectares = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FieldStatID = c.Int(nullable: false),
                        LandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FieldID);
            
            CreateTable(
                "dbo.Lands",
                c => new
                    {
                        LandID = c.Int(nullable: false, identity: true),
                        LandName = c.String(nullable: false, maxLength: 50),
                        FarmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LandID);
            
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        FarmID = c.Int(nullable: false, identity: true),
                        FarmName = c.String(nullable: false, maxLength: 50),
                        ProvinceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FarmID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderNum = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplierID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        FarmID = c.Int(nullable: false),
                        OrderStatusID = c.Int(nullable: false),
                        OrderItem = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.OrderNum);
            
            CreateTable(
                "dbo.AuditTypes",
                c => new
                    {
                        AuditTypeID = c.Int(nullable: false, identity: true),
                        AuditTypeDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AuditTypeID);
            
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        AuditID = c.Int(nullable: false, identity: true),
                        AuditRefTable = c.String(),
                        TrxDate = c.DateTime(nullable: false),
                        TrxTime = c.DateTime(nullable: false),
                        TrxNewRecord = c.String(nullable: false),
                        TrxOldRecord = c.String(nullable: false),
                        AuditRefAtrribute = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        AuditTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuditID);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleID = c.Int(nullable: false, identity: true),
                        TitleDescr = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.TitleID);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        GenderDescr = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.FarmWorkerTypes",
                c => new
                    {
                        FarmWorkerTypeID = c.Int(nullable: false, identity: true),
                        FarmWorkerTypeDescr = c.String(nullable: false, maxLength: 50),
                        FarmWorkerTypeActiveStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FarmWorkerTypeID);
            
            CreateTable(
                "dbo.FarmWorkers",
                c => new
                    {
                        FarmWorkerNum = c.Int(nullable: false, identity: true),
                        FarmWorkerFName = c.String(nullable: false, maxLength: 50),
                        FarmWorkerLName = c.String(nullable: false, maxLength: 50),
                        FarmWorkerContactNum = c.String(nullable: false, maxLength: 10),
                        FarmWorkerPhysicalAddress = c.String(nullable: false, maxLength: 100),
                        ContractStartDate = c.DateTime(nullable: false),
                        ContractEndDate = c.DateTime(nullable: false),
                        FarmWorkerIDNum = c.String(nullable: false, maxLength: 13),
                        TitleID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        FarmWorkerTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FarmWorkerNum);
            
            CreateTable(
                "dbo.AttendenceSheets",
                c => new
                    {
                        AttendenceSheetID = c.Int(nullable: false, identity: true),
                        ClockInTime = c.DateTime(nullable: false),
                        ClockOutTime = c.DateTime(nullable: false),
                        FarmWorkerNum = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendenceSheetID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        UserEmailAddress = c.String(nullable: false, maxLength: 50),
                        UserPassword = c.String(nullable: false, maxLength: 50),
                        UserContractNum = c.String(nullable: false, maxLength: 10),
                        UserFName = c.String(nullable: false, maxLength: 50),
                        UserLName = c.String(nullable: false, maxLength: 50),
                        UserIDNum = c.String(nullable: false, maxLength: 13),
                        UserAccessLevelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.AspNetUsers", "User_UserID", c => c.Int());
            DropColumn("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.Logs", "UserAccessLevelID");
            CreateIndex("dbo.VehicleServices", "VehicleID");
            CreateIndex("dbo.Vehicles", "VehMakeID");
            CreateIndex("dbo.Vehicles", "VehTypeID");
            CreateIndex("dbo.Vehicles", "FarmID");
            CreateIndex("dbo.Provinces", "CountryID");
            CreateIndex("dbo.RainfallRecords", "LandID");
            CreateIndex("dbo.Sales", "CustomerID");
            CreateIndex("dbo.SiloHarvestSales", "SaleID");
            CreateIndex("dbo.SiloHarvestSales", "SiloHarvestID");
            CreateIndex("dbo.SiloHarvests", "PlantationID");
            CreateIndex("dbo.SiloHarvests", "SiloID");
            CreateIndex("dbo.Plantations", "FieldStageID");
            CreateIndex("dbo.Plantations", "CropCycleID");
            CreateIndex("dbo.Plantations", "CropTypeID");
            CreateIndex("dbo.Plantations", "FieldID");
            CreateIndex("dbo.OrderLines", "InventoryID");
            CreateIndex("dbo.OrderLines", "OrderNum");
            CreateIndex("dbo.Inventories", "InvTypeID");
            CreateIndex("dbo.InventoryTreatments", "InventoryID");
            CreateIndex("dbo.InventoryTreatments", "TreatmentID");
            CreateIndex("dbo.FieldTreatments", "TreatmentID");
            CreateIndex("dbo.FieldTreatments", "FieldID");
            CreateIndex("dbo.FieldNaturalDisasters", "NatDisasterID");
            CreateIndex("dbo.FieldNaturalDisasters", "FieldID");
            CreateIndex("dbo.FieldBiologicalDisasters", "BioDisasterID");
            CreateIndex("dbo.FieldBiologicalDisasters", "FieldID");
            CreateIndex("dbo.Fields", "LandID");
            CreateIndex("dbo.Fields", "FieldStatID");
            CreateIndex("dbo.Lands", "FarmID");
            CreateIndex("dbo.Farms", "ProvinceID");
            CreateIndex("dbo.Orders", "OrderStatusID");
            CreateIndex("dbo.Orders", "FarmID");
            CreateIndex("dbo.Orders", "UserID");
            CreateIndex("dbo.Orders", "SupplierID");
            CreateIndex("dbo.Audits", "AuditTypeID");
            CreateIndex("dbo.Audits", "UserID");
            CreateIndex("dbo.FarmWorkers", "FarmWorkerTypeID");
            CreateIndex("dbo.FarmWorkers", "GenderID");
            CreateIndex("dbo.FarmWorkers", "TitleID");
            CreateIndex("dbo.AttendenceSheets", "UserID");
            CreateIndex("dbo.AttendenceSheets", "FarmWorkerNum");
            CreateIndex("dbo.Users", "UserAccessLevelID");
            CreateIndex("dbo.AspNetUsers", "User_UserID");
            AddForeignKey("dbo.AspNetUsers", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Users", "UserAccessLevelID", "dbo.UserAccessLevels", "UserAccessLevelID", cascadeDelete: true);
            AddForeignKey("dbo.Logs", "UserAccessLevelID", "dbo.UserAccessLevels", "UserAccessLevelID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "SupplierID", "dbo.Suppliers", "SupplierID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatus", "OrderStatusID", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "VehTypeID", "dbo.VehicleTypes", "VehTypeID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleServices", "VehicleID", "dbo.Vehicles", "VehicleID", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "VehMakeID", "dbo.VehicleMakes", "VehMakeID", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "FarmID", "dbo.Farms", "FarmID", cascadeDelete: true);
            AddForeignKey("dbo.Farms", "ProvinceID", "dbo.Provinces", "ProvinceID", cascadeDelete: true);
            AddForeignKey("dbo.Provinces", "CountryID", "dbo.Countries", "CountryID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "FarmID", "dbo.Farms", "FarmID", cascadeDelete: true);
            AddForeignKey("dbo.RainfallRecords", "LandID", "dbo.Lands", "LandID", cascadeDelete: true);
            AddForeignKey("dbo.SiloHarvestSales", "SiloHarvestID", "dbo.SiloHarvests", "SiloHarvestID", cascadeDelete: true);
            AddForeignKey("dbo.SiloHarvestSales", "SaleID", "dbo.Sales", "SaleID", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.SiloHarvests", "SiloID", "dbo.Silos", "SiloID", cascadeDelete: true);
            AddForeignKey("dbo.SiloHarvests", "PlantationID", "dbo.Plantations", "PlantationID", cascadeDelete: true);
            AddForeignKey("dbo.Plantations", "FieldStageID", "dbo.FieldStages", "FieldStageID", cascadeDelete: true);
            AddForeignKey("dbo.Plantations", "FieldID", "dbo.Fields", "FieldID", cascadeDelete: true);
            AddForeignKey("dbo.Plantations", "CropTypeID", "dbo.CropTypes", "CropTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Plantations", "CropCycleID", "dbo.CropCycles", "CropCycleID", cascadeDelete: true);
            AddForeignKey("dbo.Fields", "LandID", "dbo.Lands", "LandID", cascadeDelete: true);
            AddForeignKey("dbo.InventoryTreatments", "TreatmentID", "dbo.Treatments", "TreatmentID", cascadeDelete: true);
            AddForeignKey("dbo.OrderLines", "OrderNum", "dbo.Orders", "OrderNum", cascadeDelete: true);
            AddForeignKey("dbo.OrderLines", "InventoryID", "dbo.Inventories", "InventoryID", cascadeDelete: true);
            AddForeignKey("dbo.Inventories", "InvTypeID", "dbo.InventoryTypes", "InvTypeID", cascadeDelete: true);
            AddForeignKey("dbo.InventoryTreatments", "InventoryID", "dbo.Inventories", "InventoryID", cascadeDelete: true);
            AddForeignKey("dbo.FieldTreatments", "TreatmentID", "dbo.Treatments", "TreatmentID", cascadeDelete: true);
            AddForeignKey("dbo.FieldTreatments", "FieldID", "dbo.Fields", "FieldID", cascadeDelete: true);
            AddForeignKey("dbo.Fields", "FieldStatID", "dbo.FieldStatus", "FieldStatID", cascadeDelete: true);
            AddForeignKey("dbo.FieldNaturalDisasters", "NatDisasterID", "dbo.NaturalDisasters", "NatDisasterID", cascadeDelete: true);
            AddForeignKey("dbo.FieldNaturalDisasters", "FieldID", "dbo.Fields", "FieldID", cascadeDelete: true);
            AddForeignKey("dbo.FieldBiologicalDisasters", "FieldID", "dbo.Fields", "FieldID", cascadeDelete: true);
            AddForeignKey("dbo.FieldBiologicalDisasters", "BioDisasterID", "dbo.BiologicalDisasters", "BioDisasterID", cascadeDelete: true);
            AddForeignKey("dbo.Lands", "FarmID", "dbo.Farms", "FarmID", cascadeDelete: true);
            AddForeignKey("dbo.Audits", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Audits", "AuditTypeID", "dbo.AuditTypes", "AuditTypeID", cascadeDelete: true);
            AddForeignKey("dbo.AttendenceSheets", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.FarmWorkers", "TitleID", "dbo.Titles", "TitleID", cascadeDelete: true);
            AddForeignKey("dbo.FarmWorkers", "GenderID", "dbo.Genders", "GenderID", cascadeDelete: true);
            AddForeignKey("dbo.FarmWorkers", "FarmWorkerTypeID", "dbo.FarmWorkerTypes", "FarmWorkerTypeID", cascadeDelete: true);
            AddForeignKey("dbo.AttendenceSheets", "FarmWorkerNum", "dbo.FarmWorkers", "FarmWorkerNum", cascadeDelete: true);
        }
    }
}
