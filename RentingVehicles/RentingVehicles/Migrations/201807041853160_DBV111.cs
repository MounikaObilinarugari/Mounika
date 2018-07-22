namespace RentingVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBV111 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tbl_messages", "SentBy");
            DropColumn("dbo.tbl_messages", "SendTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_messages", "SendTo", c => c.String(nullable: false));
            AddColumn("dbo.tbl_messages", "SentBy", c => c.String(nullable: false));
        }
    }
}
