namespace WasteManagement1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "PostalCode_PostalCodeId", c => c.Int());
            AddColumn("dbo.Customers", "Address_Id", c => c.Int());
            AddColumn("dbo.Employees", "Address_Id", c => c.Int());
            CreateIndex("dbo.Addresses", "PostalCode_PostalCodeId");
            CreateIndex("dbo.Customers", "Address_Id");
            CreateIndex("dbo.Employees", "Address_Id");
            AddForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Addresses", "PostalCode_PostalCodeId", "dbo.PostalCodes", "PostalCodeId");
            DropColumn("dbo.Addresses", "postalCodeId");
            DropColumn("dbo.Customers", "pickupAddress");
            DropColumn("dbo.Customers", "billingAddress");
            DropColumn("dbo.Employees", "PhysicalAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "PhysicalAddress", c => c.Int());
            AddColumn("dbo.Customers", "billingAddress", c => c.Int());
            AddColumn("dbo.Customers", "pickupAddress", c => c.Int());
            AddColumn("dbo.Addresses", "postalCodeId", c => c.Int());
            DropForeignKey("dbo.Addresses", "PostalCode_PostalCodeId", "dbo.PostalCodes");
            DropForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Employees", new[] { "Address_Id" });
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            DropIndex("dbo.Addresses", new[] { "PostalCode_PostalCodeId" });
            DropColumn("dbo.Employees", "Address_Id");
            DropColumn("dbo.Customers", "Address_Id");
            DropColumn("dbo.Addresses", "PostalCode_PostalCodeId");
        }
    }
}
