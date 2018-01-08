namespace Ajf.RideShare.Migrate
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCar : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cars", name: "Event_EventId", newName: "EventId");
            RenameIndex(table: "dbo.Cars", name: "IX_Event_EventId", newName: "IX_EventId");
            AddColumn("dbo.Cars", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Phone");
            RenameIndex(table: "dbo.Cars", name: "IX_EventId", newName: "IX_Event_EventId");
            RenameColumn(table: "dbo.Cars", name: "EventId", newName: "Event_EventId");
        }
    }
}
