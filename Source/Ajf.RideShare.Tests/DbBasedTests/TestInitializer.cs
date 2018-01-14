using System;
using System.Data.Entity;
using Ajf.RideShare.Models;
using Ploeh.AutoFixture;

namespace Ajf.RideShare.Tests.DbBasedTests
{
    public class TestInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        public override void InitializeDatabase(ApplicationDbContext context)
        {
            base.InitializeDatabase(context);

            var @event = new Fixture().Build<Event>().Create();
            context.Events.Add(@event);

            context.SaveChanges();
        }
    }
}