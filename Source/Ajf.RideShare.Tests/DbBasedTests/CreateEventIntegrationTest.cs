using System;
using System.Linq;
using Ajf.RideShare.Api;
using Ajf.RideShare.Api.Repositories;
using Ajf.RideShare.Api.UnitOfWork.Events;
using Ajf.RideShare.Models;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Ajf.RideShare.Tests.DbBasedTests
{
    [TestFixture]
    [Category("Database")]
    public class CreateEventIntegrationTest : IntegrationTestBase
    {
        [Test]
        public void ThatDatabaseCanBeCreatedAndDeleted()
        {
            var dbContextProvider =new DbTestContextProvider(ConnectionString);

            var before = DbContext.Events.Count();

            using (var sut = new CreateEvent(Guid.NewGuid().ToString(), new EventRepository(dbContextProvider)))
            {
                var eventForCreation =new Fixture().Build<EventForCreation>().Create(); 
                sut.Execute(eventForCreation);
            }
            var after = DbContext.Events.Count();

            Assert.That((after-before).Equals(1));
        }
    }
}