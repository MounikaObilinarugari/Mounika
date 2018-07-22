namespace RentingVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBV115 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_wishlist",
                c => new
                    {
                        wishlistid = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        VehicleID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.wishlistid)
                .ForeignKey("dbo.tbl_NewUser", t => t.UserID)
                .ForeignKey("dbo.tbl_AddVehicle", t => t.VehicleID)
                .Index(t => t.UserID)
                .Index(t => t.VehicleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_wishlist", "VehicleID", "dbo.tbl_AddVehicle");
            DropForeignKey("dbo.tbl_wishlist", "UserID", "dbo.tbl_NewUser");
            DropIndex("dbo.tbl_wishlist", new[] { "VehicleID" });
            DropIndex("dbo.tbl_wishlist", new[] { "UserID" });
            DropTable("dbo.tbl_wishlist");
        }
    }
}
