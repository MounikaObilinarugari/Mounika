namespace RentingVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBV1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_AddVehicle", "UserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.tbl_AddVehicle", "UserID");
            AddForeignKey("dbo.tbl_AddVehicle", "UserID", "dbo.tbl_NewUser", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_AddVehicle", "UserID", "dbo.tbl_NewUser");
            DropIndex("dbo.tbl_AddVehicle", new[] { "UserID" });
            DropColumn("dbo.tbl_AddVehicle", "UserID");
        }
    }
}
