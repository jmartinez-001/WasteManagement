namespace WasteManagement1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customeredit3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickUpDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickUpDay", c => c.String());
        }
    }
}
