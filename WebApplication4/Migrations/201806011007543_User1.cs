namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User1 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserAccessLevels", t => t.UserAccessLevelID, cascadeDelete: true)
                .Index(t => t.UserAccessLevelID);
            
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
                .PrimaryKey(t => t.AttendenceSheetID)
                .ForeignKey("dbo.FarmWorkers", t => t.FarmWorkerNum, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.FarmWorkerNum)
                .Index(t => t.UserID);
            
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
                .PrimaryKey(t => t.FarmWorkerNum)
                .ForeignKey("dbo.FarmWorkerTypes", t => t.FarmWorkerTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderID, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleID, cascadeDelete: true)
                .Index(t => t.TitleID)
                .Index(t => t.GenderID)
                .Index(t => t.FarmWorkerTypeID);
            
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
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        GenderDescr = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleID = c.Int(nullable: false, identity: true),
                        TitleDescr = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.TitleID);
            
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
                .PrimaryKey(t => t.AuditID)
                .ForeignKey("dbo.AuditTypes", t => t.AuditTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.AuditTypeID);
            
            CreateTable(
                "dbo.AuditTypes",
                c => new
                    {
                        AuditTypeID = c.Int(nullable: false, identity: true),
                        AuditTypeDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AuditTypeID);
            
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
                .PrimaryKey(t => t.OrderNum)
                .ForeignKey("dbo.Farms", t => t.FarmID, cascadeDelete: true)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.UserID)
                .Index(t => t.FarmID)
                .Index(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        FarmID = c.Int(nullable: false, identity: true),
                        FarmName = c.String(nullable: false, maxLength: 50),
                        ProvinceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FarmID)
                .ForeignKey("dbo.Provinces", t => t.ProvinceID, cascadeDelete: true)
                .Index(t => t.ProvinceID);
            
            CreateTable(
                "dbo.Lands",
                c => new
                    {
                        LandID = c.Int(nullable: false, identity: true),
                        LandName = c.String(nullable: false, maxLength: 50),
                        FarmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LandID)
                .ForeignKey("dbo.Farms", t => t.FarmID, cascadeDelete: true)
                .Index(t => t.FarmID);
            
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
                .PrimaryKey(t => t.FieldID)
                .ForeignKey("dbo.FieldStatus", t => t.FieldStatID, cascadeDelete: true)
                .ForeignKey("dbo.Lands", t => t.LandID, cascadeDelete: true)
                .Index(t => t.FieldStatID)
                .Index(t => t.LandID);
            
            CreateTable(
                "dbo.FieldBiologicalDisasters",
                c => new
                    {
                        FieldID = c.Int(nullable: false),
                        BioDisasterID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.FieldID, t.BioDisasterID })
                .ForeignKey("dbo.BiologicalDisasters", t => t.BioDisasterID, cascadeDelete: true)
                .ForeignKey("dbo.Fields", t => t.FieldID, cascadeDelete: true)
                .Index(t => t.FieldID)
                .Index(t => t.BioDisasterID);
            
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
                "dbo.FieldNaturalDisasters",
                c => new
                    {
                        FieldID = c.Int(nullable: false),
                        NatDisasterID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.FieldID, t.NatDisasterID })
                .ForeignKey("dbo.Fields", t => t.FieldID, cascadeDelete: true)
                .ForeignKey("dbo.NaturalDisasters", t => t.NatDisasterID, cascadeDelete: true)
                .Index(t => t.FieldID)
                .Index(t => t.NatDisasterID);
            
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
                "dbo.FieldStatus",
                c => new
                    {
                        FieldStatID = c.Int(nullable: false, identity: true),
                        FieldStatDescr = c.String(nullable: false, maxLength: 50),
                        StatPreConditions = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FieldStatID);
            
            CreateTable(
                "dbo.FieldTreatments",
                c => new
                    {
                        FieldID = c.Int(nullable: false),
                        TreatmentID = c.Int(nullable: false),
                        TreatmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.FieldID, t.TreatmentID })
                .ForeignKey("dbo.Fields", t => t.FieldID, cascadeDelete: true)
                .ForeignKey("dbo.Treatments", t => t.TreatmentID, cascadeDelete: true)
                .Index(t => t.FieldID)
                .Index(t => t.TreatmentID);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatmentID = c.Int(nullable: false, identity: true),
                        TreatmentDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TreatmentID);
            
            CreateTable(
                "dbo.InventoryTreatments",
                c => new
                    {
                        TreatmentID = c.Int(nullable: false),
                        InventoryID = c.Int(nullable: false),
                        TreatmentQnty = c.Int(nullable: false),
                        TreatmentUnit = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.TreatmentID, t.InventoryID })
                .ForeignKey("dbo.Inventories", t => t.InventoryID, cascadeDelete: true)
                .ForeignKey("dbo.Treatments", t => t.TreatmentID, cascadeDelete: true)
                .Index(t => t.TreatmentID)
                .Index(t => t.InventoryID);
            
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
                .PrimaryKey(t => t.InventoryID)
                .ForeignKey("dbo.InventoryTypes", t => t.InvTypeID, cascadeDelete: true)
                .Index(t => t.InvTypeID);
            
            CreateTable(
                "dbo.InventoryTypes",
                c => new
                    {
                        InvTypeID = c.Int(nullable: false, identity: true),
                        InvTypeDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.InvTypeID);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        OrderNum = c.Int(nullable: false),
                        InventoryID = c.Int(nullable: false),
                        OrderLineTotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderLineTotalQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderNum, t.InventoryID })
                .ForeignKey("dbo.Inventories", t => t.InventoryID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderNum, cascadeDelete: true)
                .Index(t => t.OrderNum)
                .Index(t => t.InventoryID);
            
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
                .PrimaryKey(t => t.PlantationID)
                .ForeignKey("dbo.CropCycles", t => t.CropCycleID, cascadeDelete: true)
                .ForeignKey("dbo.CropTypes", t => t.CropTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Fields", t => t.FieldID, cascadeDelete: true)
                .ForeignKey("dbo.FieldStages", t => t.FieldStageID, cascadeDelete: true)
                .Index(t => t.FieldID)
                .Index(t => t.CropTypeID)
                .Index(t => t.CropCycleID)
                .Index(t => t.FieldStageID);
            
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
                "dbo.CropTypes",
                c => new
                    {
                        CropTypeID = c.Int(nullable: false, identity: true),
                        CropTypeDescr = c.String(nullable: false, maxLength: 50),
                        MaturityDays = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CropTypeID);
            
            CreateTable(
                "dbo.FieldStages",
                c => new
                    {
                        FieldStageID = c.Int(nullable: false, identity: true),
                        FieldStageDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FieldStageID);
            
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
                .PrimaryKey(t => t.SiloHarvestID)
                .ForeignKey("dbo.Plantations", t => t.PlantationID, cascadeDelete: true)
                .ForeignKey("dbo.Silos", t => t.SiloID, cascadeDelete: true)
                .Index(t => t.SiloID)
                .Index(t => t.PlantationID);
            
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
                "dbo.SiloHarvestSales",
                c => new
                    {
                        SiloHarvestID = c.Int(nullable: false),
                        SaleID = c.Int(nullable: false),
                        SiloHarvestSaleTotalAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SiloHarvestSaleTotalQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.SiloHarvestID, t.SaleID })
                .ForeignKey("dbo.Sales", t => t.SaleID, cascadeDelete: true)
                .ForeignKey("dbo.SiloHarvests", t => t.SiloHarvestID, cascadeDelete: true)
                .Index(t => t.SiloHarvestID)
                .Index(t => t.SaleID);
            
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
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
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
                "dbo.RainfallRecords",
                c => new
                    {
                        RainFallRecID = c.Int(nullable: false, identity: true),
                        RecordDate = c.DateTime(nullable: false),
                        RecordMeasurement = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RainFallRecID)
                .ForeignKey("dbo.Lands", t => t.LandID, cascadeDelete: true)
                .Index(t => t.LandID);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceID = c.Int(nullable: false, identity: true),
                        ProvinceDescr = c.String(nullable: false, maxLength: 50),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CountryID);
            
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
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.Farms", t => t.FarmID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleMakes", t => t.VehMakeID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehTypeID, cascadeDelete: true)
                .Index(t => t.FarmID)
                .Index(t => t.VehTypeID)
                .Index(t => t.VehMakeID);
            
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        VehMakeID = c.Int(nullable: false, identity: true),
                        VehMakeDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VehMakeID);
            
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
                .PrimaryKey(t => t.VehicleServiceID)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehTypeID = c.Int(nullable: false, identity: true),
                        VehTypeDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VehTypeID);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusID = c.Int(nullable: false, identity: true),
                        OrderStatusDescr = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.OrderStatusID);
            
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
                "dbo.UserAccessLevels",
                c => new
                    {
                        UserAccessLevelID = c.Int(nullable: false, identity: true),
                        UserAccessLevelDescr = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserAccessLevelID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        LogInTimeStamp = c.DateTime(nullable: false),
                        LogOutTimeStamp = c.DateTime(nullable: false),
                        UserAccessLevelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.UserAccessLevels", t => t.UserAccessLevelID, cascadeDelete: true)
                .Index(t => t.UserAccessLevelID);
            
            AddColumn("dbo.AspNetUsers", "User_UserID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "User_UserID");
            AddForeignKey("dbo.AspNetUsers", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "UserAccessLevelID", "dbo.UserAccessLevels");
            DropForeignKey("dbo.Logs", "UserAccessLevelID", "dbo.UserAccessLevels");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatus");
            DropForeignKey("dbo.Vehicles", "VehTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleServices", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehMakeID", "dbo.VehicleMakes");
            DropForeignKey("dbo.Vehicles", "FarmID", "dbo.Farms");
            DropForeignKey("dbo.Farms", "ProvinceID", "dbo.Provinces");
            DropForeignKey("dbo.Provinces", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Orders", "FarmID", "dbo.Farms");
            DropForeignKey("dbo.RainfallRecords", "LandID", "dbo.Lands");
            DropForeignKey("dbo.SiloHarvestSales", "SiloHarvestID", "dbo.SiloHarvests");
            DropForeignKey("dbo.SiloHarvestSales", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.SiloHarvests", "SiloID", "dbo.Silos");
            DropForeignKey("dbo.SiloHarvests", "PlantationID", "dbo.Plantations");
            DropForeignKey("dbo.Plantations", "FieldStageID", "dbo.FieldStages");
            DropForeignKey("dbo.Plantations", "FieldID", "dbo.Fields");
            DropForeignKey("dbo.Plantations", "CropTypeID", "dbo.CropTypes");
            DropForeignKey("dbo.Plantations", "CropCycleID", "dbo.CropCycles");
            DropForeignKey("dbo.Fields", "LandID", "dbo.Lands");
            DropForeignKey("dbo.InventoryTreatments", "TreatmentID", "dbo.Treatments");
            DropForeignKey("dbo.OrderLines", "OrderNum", "dbo.Orders");
            DropForeignKey("dbo.OrderLines", "InventoryID", "dbo.Inventories");
            DropForeignKey("dbo.Inventories", "InvTypeID", "dbo.InventoryTypes");
            DropForeignKey("dbo.InventoryTreatments", "InventoryID", "dbo.Inventories");
            DropForeignKey("dbo.FieldTreatments", "TreatmentID", "dbo.Treatments");
            DropForeignKey("dbo.FieldTreatments", "FieldID", "dbo.Fields");
            DropForeignKey("dbo.Fields", "FieldStatID", "dbo.FieldStatus");
            DropForeignKey("dbo.FieldNaturalDisasters", "NatDisasterID", "dbo.NaturalDisasters");
            DropForeignKey("dbo.FieldNaturalDisasters", "FieldID", "dbo.Fields");
            DropForeignKey("dbo.FieldBiologicalDisasters", "FieldID", "dbo.Fields");
            DropForeignKey("dbo.FieldBiologicalDisasters", "BioDisasterID", "dbo.BiologicalDisasters");
            DropForeignKey("dbo.Lands", "FarmID", "dbo.Farms");
            DropForeignKey("dbo.Audits", "UserID", "dbo.Users");
            DropForeignKey("dbo.Audits", "AuditTypeID", "dbo.AuditTypes");
            DropForeignKey("dbo.AttendenceSheets", "UserID", "dbo.Users");
            DropForeignKey("dbo.FarmWorkers", "TitleID", "dbo.Titles");
            DropForeignKey("dbo.FarmWorkers", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.FarmWorkers", "FarmWorkerTypeID", "dbo.FarmWorkerTypes");
            DropForeignKey("dbo.AttendenceSheets", "FarmWorkerNum", "dbo.FarmWorkers");
            DropIndex("dbo.Logs", new[] { "UserAccessLevelID" });
            DropIndex("dbo.VehicleServices", new[] { "VehicleID" });
            DropIndex("dbo.Vehicles", new[] { "VehMakeID" });
            DropIndex("dbo.Vehicles", new[] { "VehTypeID" });
            DropIndex("dbo.Vehicles", new[] { "FarmID" });
            DropIndex("dbo.Provinces", new[] { "CountryID" });
            DropIndex("dbo.RainfallRecords", new[] { "LandID" });
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropIndex("dbo.SiloHarvestSales", new[] { "SaleID" });
            DropIndex("dbo.SiloHarvestSales", new[] { "SiloHarvestID" });
            DropIndex("dbo.SiloHarvests", new[] { "PlantationID" });
            DropIndex("dbo.SiloHarvests", new[] { "SiloID" });
            DropIndex("dbo.Plantations", new[] { "FieldStageID" });
            DropIndex("dbo.Plantations", new[] { "CropCycleID" });
            DropIndex("dbo.Plantations", new[] { "CropTypeID" });
            DropIndex("dbo.Plantations", new[] { "FieldID" });
            DropIndex("dbo.OrderLines", new[] { "InventoryID" });
            DropIndex("dbo.OrderLines", new[] { "OrderNum" });
            DropIndex("dbo.Inventories", new[] { "InvTypeID" });
            DropIndex("dbo.InventoryTreatments", new[] { "InventoryID" });
            DropIndex("dbo.InventoryTreatments", new[] { "TreatmentID" });
            DropIndex("dbo.FieldTreatments", new[] { "TreatmentID" });
            DropIndex("dbo.FieldTreatments", new[] { "FieldID" });
            DropIndex("dbo.FieldNaturalDisasters", new[] { "NatDisasterID" });
            DropIndex("dbo.FieldNaturalDisasters", new[] { "FieldID" });
            DropIndex("dbo.FieldBiologicalDisasters", new[] { "BioDisasterID" });
            DropIndex("dbo.FieldBiologicalDisasters", new[] { "FieldID" });
            DropIndex("dbo.Fields", new[] { "LandID" });
            DropIndex("dbo.Fields", new[] { "FieldStatID" });
            DropIndex("dbo.Lands", new[] { "FarmID" });
            DropIndex("dbo.Farms", new[] { "ProvinceID" });
            DropIndex("dbo.Orders", new[] { "OrderStatusID" });
            DropIndex("dbo.Orders", new[] { "FarmID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Orders", new[] { "SupplierID" });
            DropIndex("dbo.Audits", new[] { "AuditTypeID" });
            DropIndex("dbo.Audits", new[] { "UserID" });
            DropIndex("dbo.FarmWorkers", new[] { "FarmWorkerTypeID" });
            DropIndex("dbo.FarmWorkers", new[] { "GenderID" });
            DropIndex("dbo.FarmWorkers", new[] { "TitleID" });
            DropIndex("dbo.AttendenceSheets", new[] { "UserID" });
            DropIndex("dbo.AttendenceSheets", new[] { "FarmWorkerNum" });
            DropIndex("dbo.Users", new[] { "UserAccessLevelID" });
            DropIndex("dbo.AspNetUsers", new[] { "User_UserID" });
            DropColumn("dbo.AspNetUsers", "User_UserID");
            DropTable("dbo.Logs");
            DropTable("dbo.UserAccessLevels");
            DropTable("dbo.Suppliers");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleServices");
            DropTable("dbo.VehicleMakes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Countries");
            DropTable("dbo.Provinces");
            DropTable("dbo.RainfallRecords");
            DropTable("dbo.Customers");
            DropTable("dbo.Sales");
            DropTable("dbo.SiloHarvestSales");
            DropTable("dbo.Silos");
            DropTable("dbo.SiloHarvests");
            DropTable("dbo.FieldStages");
            DropTable("dbo.CropTypes");
            DropTable("dbo.CropCycles");
            DropTable("dbo.Plantations");
            DropTable("dbo.OrderLines");
            DropTable("dbo.InventoryTypes");
            DropTable("dbo.Inventories");
            DropTable("dbo.InventoryTreatments");
            DropTable("dbo.Treatments");
            DropTable("dbo.FieldTreatments");
            DropTable("dbo.FieldStatus");
            DropTable("dbo.NaturalDisasters");
            DropTable("dbo.FieldNaturalDisasters");
            DropTable("dbo.BiologicalDisasters");
            DropTable("dbo.FieldBiologicalDisasters");
            DropTable("dbo.Fields");
            DropTable("dbo.Lands");
            DropTable("dbo.Farms");
            DropTable("dbo.Orders");
            DropTable("dbo.AuditTypes");
            DropTable("dbo.Audits");
            DropTable("dbo.Titles");
            DropTable("dbo.Genders");
            DropTable("dbo.FarmWorkerTypes");
            DropTable("dbo.FarmWorkers");
            DropTable("dbo.AttendenceSheets");
            DropTable("dbo.Users");
        }
    }
}
