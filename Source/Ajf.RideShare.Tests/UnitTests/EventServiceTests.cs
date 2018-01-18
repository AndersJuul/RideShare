using System;
using System.Linq;
using Ajf.RideShare.Api.Logic.Queries;
using Ajf.RideShare.Models;
using Ajf.RideShare.Tests.UnitTests.Contexts;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Ajf.RideShare.Tests.UnitTests
{
    [TestFixture]
    public class EventServiceTests
    {
        [Test]
        public void ThatServiceCreatesEvent()
        {
            // Arrange
            var context = EventServiceContext.GivenContext();
            var before = context.Repository.Find(new GetEvents()).Count();
            var @event = context.Fixture.Build<Event>().Create();

            // Act
            context.EventService.AddEvent(@event);

            // Assert
            var after = context.Repository.Find(new GetEvents()).Count();
            Assert.That((after - before).Equals(1));
        }

        [Test]
        public void ThatServiceReturnsEventsByOwnerId()
        {
            // Arrange
            var ownerId = Guid.NewGuid();
            var context = EventServiceContext.GivenContext();
            context.WithSingleEvent(ownerId);

            // Act
            var events = context.EventService.GetEvents(ownerId.ToString());

            // Assert
            Assert.AreEqual(1, events.Count());
        }
    }
}