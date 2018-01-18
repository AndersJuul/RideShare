﻿using System;
using System.Linq;
using Ajf.RideShare.Api.Logic.Queries;
using Ajf.RideShare.Models;
using Ajf.RideShare.Tests.UnitTests.Contexts;
using Highway.Data;
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

        [Test]
        public void ThatServiceCanUpdateEvent()
        {
            // Arrange
            var ownerId = Guid.NewGuid();
            var context = EventServiceContext.GivenContext();
            var singleEvent = context.WithSingleEvent(ownerId);
            var description = context.Fixture.Create<string>();

            // Act
            singleEvent.Description = description;
            var events = context.EventService.UpdateEvent(singleEvent);

            // Assert
            Assert.AreEqual(description, context.Repository.Find(new GetEventById(singleEvent.EventId)).Description);
        }
    }

    public class GetEventById : Scalar<Event>
    {
        public GetEventById(Guid eventId)
        {
            ContextQuery = context => context.AsQueryable<Event>().SingleOrDefault(x => x.EventId == eventId);
        }
    }
}