namespace Ajf.RideShare.Migrate
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventExtend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "OwnerId", c => c.String(nullable: false));
            AddColumn("dbo.Events", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Events", "UserSub");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "UserSub", c => c.Guid(nullable: false));
            DropColumn("dbo.Events", "Description");
            DropColumn("dbo.Events", "OwnerId");
        }
    }
}
