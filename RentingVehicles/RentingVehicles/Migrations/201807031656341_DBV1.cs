namespace RentingVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBV1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_AddVehicle", "VehicleImageAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_AddVehicle", "VehicleImageAddress", c => c.String(nullable: false));
        }
    }
}
