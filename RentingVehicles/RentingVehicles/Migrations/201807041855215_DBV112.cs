namespace RentingVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBV112 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_messages", "MessageContent", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_messages", "MessageContent", c => c.String(nullable: false));
        }
    }
}
