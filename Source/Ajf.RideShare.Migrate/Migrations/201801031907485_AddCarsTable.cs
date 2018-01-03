namespace Ajf.RideShare.Migrate
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Guid(nullable: false),
                        Description = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Event_EventId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Events", t => t.Event_EventId, cascadeDelete: true)
                .Index(t => t.Event_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Cars", new[] { "Event_EventId" });
            DropTable("dbo.Cars");
        }
    }
}
