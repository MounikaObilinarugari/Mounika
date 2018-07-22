namespace RentingVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBV18 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_messages", "SentBy", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_messages", "SendTo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_messages", "SendTo", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_messages", "SentBy", c => c.Int(nullable: false));
        }
    }
}
