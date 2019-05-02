namespace WasteManagement1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcountryproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Country", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CountryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CountryName");
            DropColumn("dbo.Customers", "Country");
        }
    }
}
