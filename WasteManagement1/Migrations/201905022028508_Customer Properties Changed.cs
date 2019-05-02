namespace WasteManagement1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerPropertiesChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        MapReference = c.String(),
                        CountryCode = c.String(),
                        CountryCodeLong = c.String(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            AddColumn("dbo.Customers", "Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Customers", "Longitude", c => c.Single(nullable: false));
            AddColumn("dbo.Customers", "CountryCode", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "State", c => c.String(nullable: false));
            DropColumn("dbo.Pickups", "Lat");
            DropColumn("dbo.Pickups", "Long");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pickups", "Long", c => c.String());
            AddColumn("dbo.Pickups", "Lat", c => c.String());
            DropForeignKey("dbo.Countries", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Countries", new[] { "Customer_Id" });
            AlterColumn("dbo.Customers", "State", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            DropColumn("dbo.Customers", "CountryCode");
            DropColumn("dbo.Customers", "Longitude");
            DropColumn("dbo.Customers", "Latitude");
            DropTable("dbo.Countries");
        }
    }
}
