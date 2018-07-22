namespace RentingVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBV11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_AddVehicle", "City", c => c.String(nullable: false));
            AddColumn("dbo.tbl_AddVehicle", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_AddVehicle", "Location");
            DropColumn("dbo.tbl_AddVehicle", "City");
        }
    }
}
