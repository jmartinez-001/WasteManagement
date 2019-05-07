namespace WasteManagement1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcustomerviewmodeltopassinformationtotheemployeedetailsview : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "ZipCode", c => c.Int(nullable: false));
        }
    }
}
