namespace WasteManagement1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrequiredfieldsincustomermodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "State", c => c.String());
            AlterColumn("dbo.Customers", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
        }
    }
}
