namespace Ajf.RideShare.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "CreateTime");
        }
    }
}
