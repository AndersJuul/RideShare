namespace Ajf.RideShare.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedids : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Guid(nullable: false),
                        EventId = c.Guid(nullable: false),
                        Description = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        OwnerId = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);

            Sql("Update Events set Id=EventId");
            Sql("Update Cars set Id=CarId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Cars", "EventId", "dbo.Events");
            DropIndex("dbo.Cars", new[] { "EventId" });
            DropTable("dbo.Events");
            DropTable("dbo.Cars");
        }
    }
}
