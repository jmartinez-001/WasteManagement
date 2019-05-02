namespace WasteManagement1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customerupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Countries", new[] { "Customer_Id" });
            DropColumn("dbo.Customers", "Country");
            DropColumn("dbo.Customers", "CountryName");
            DropColumn("dbo.Customers", "CountryCode");
            DropTable("dbo.Countries");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.CountryId);
            
            AddColumn("dbo.Customers", "CountryCode", c => c.String());
            AddColumn("dbo.Customers", "CountryName", c => c.String());
            AddColumn("dbo.Customers", "Country", c => c.String(nullable: false));
            CreateIndex("dbo.Countries", "Customer_Id");
            AddForeignKey("dbo.Countries", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
