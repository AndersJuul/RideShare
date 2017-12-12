namespace Ajf.RideShare.Migrate
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserSub = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
