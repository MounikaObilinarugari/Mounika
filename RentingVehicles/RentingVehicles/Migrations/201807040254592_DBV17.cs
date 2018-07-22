namespace RentingVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBV17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        MessageContent = c.String(nullable: false),
                        SentBy = c.Int(nullable: false),
                        SendTo = c.Int(nullable: false),
                        VehicleID = c.String(maxLength: 128),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.tbl_NewUser", t => t.UserID)
                .ForeignKey("dbo.tbl_AddVehicle", t => t.VehicleID)
                .Index(t => t.VehicleID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_messages", "VehicleID", "dbo.tbl_AddVehicle");
            DropForeignKey("dbo.tbl_messages", "UserID", "dbo.tbl_NewUser");
            DropIndex("dbo.tbl_messages", new[] { "UserID" });
            DropIndex("dbo.tbl_messages", new[] { "VehicleID" });
            DropTable("dbo.tbl_messages");
        }
    }
}
