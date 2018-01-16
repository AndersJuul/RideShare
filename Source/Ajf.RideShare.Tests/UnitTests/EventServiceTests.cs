using System;
using System.Collections.ObjectModel;
using System.Linq;
using Ajf.RideShare.Api.Logic.Queries;
using Ajf.RideShare.Api.Logic.Services;
using Ajf.RideShare.Models;
using Ajf.RideShare.Tests.Base;
using Ajf.RideShare.Tests.DbBasedTests;
using Highway.Data;
using Highway.Data.Contexts;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Ajf.RideShare.Tests.UnitTests
{
    [TestFixture]
    public class EventServiceTests:BaseUnitTests
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }
        [Test]
        public void ThatServiceCreatesEvent()
        {
            // Arrange
            var inMemoryDataContext = new InMemoryDataContext();
            var repository = new Repository(inMemoryDataContext);
            var before = repository.Find(new GetEvents()).Count();
            var sut = new EventService(repository);
            var @event = new Fixture().Build<Event>().Create();

            // Act
            sut.AddEvent(@event);

            // Assert
            var after = repository.Find(new GetEvents()).Count();
            Assert.That((after - before).Equals(1));
        }

        [Test]
        public void ThatServiceReturnsEventsByOwnerId()
        {
            // Arrange
            var @event = new Fixture().Build<Event>().With(x=>x.Date, DateTime.Now.AddDays(3)).Create();
            var inMemoryDataContext = new InMemoryDataContext();
            inMemoryDataContext.Add(@event);
            inMemoryDataContext.Commit();
            var repository = new Repository(inMemoryDataContext);
            var sut = new EventService(repository);
            
            // Act
            var events = sut.GetEvents(@event.OwnerId);

            // Assert
            Assert.AreEqual(1,events.Count());
        }
    }
}