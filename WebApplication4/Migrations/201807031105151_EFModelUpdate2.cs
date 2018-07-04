namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EFModelUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logs", "UserAccessLevelID", "dbo.UserAccessLevels");
            DropIndex("dbo.Logs", new[] { "UserAccessLevelID" });
            AddColumn("dbo.Sales", "PurchaseAgreement", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "Surburb", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Customers", "Country", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Customers", "Province", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Logs", "User", c => c.Int(nullable: false));
            AddColumn("dbo.Logs", "User1_UserID", c => c.Int());
            AlterColumn("dbo.Audits", "TrxNewRecord", c => c.String());
            AlterColumn("dbo.Audits", "TrxOldRecord", c => c.String());
            AlterColumn("dbo.Audits", "AuditRefAtrribute", c => c.String());
            CreateIndex("dbo.Logs", "User1_UserID");
            AddForeignKey("dbo.Logs", "User1_UserID", "dbo.Users", "UserID");
            DropColumn("dbo.Customers", "CompanyPhysAddress");
            DropColumn("dbo.Logs", "UserAccessLevelID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "UserAccessLevelID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CompanyPhysAddress", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Logs", "User1_UserID", "dbo.Users");
            DropIndex("dbo.Logs", new[] { "User1_UserID" });
            AlterColumn("dbo.Audits", "AuditRefAtrribute", c => c.String(nullable: false));
            AlterColumn("dbo.Audits", "TrxOldRecord", c => c.String(nullable: false));
            AlterColumn("dbo.Audits", "TrxNewRecord", c => c.String(nullable: false));
            DropColumn("dbo.Logs", "User1_UserID");
            DropColumn("dbo.Logs", "User");
            DropColumn("dbo.Customers", "Province");
            DropColumn("dbo.Customers", "Country");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Surburb");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Sales", "PurchaseAgreement");
            CreateIndex("dbo.Logs", "UserAccessLevelID");
            AddForeignKey("dbo.Logs", "UserAccessLevelID", "dbo.UserAccessLevels", "UserAccessLevelID", cascadeDelete: true);
        }
    }
}
