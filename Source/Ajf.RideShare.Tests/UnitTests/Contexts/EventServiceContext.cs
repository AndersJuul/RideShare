using System;
using Ajf.RideShare.Api.Logic.Services;
using Ajf.RideShare.Models;
using AutoFixture;
using Highway.Data;
using Highway.Data.Contexts;

namespace Ajf.RideShare.Tests.UnitTests.Contexts
{
    public class EventServiceContext : ServiceContext
    {
        protected EventServiceContext(InMemoryDataContext inMemoryDataContext, IRepository repository,
            EventService eventService, Fixture fixture) : base(fixture, repository)
        {
            InMemoryDataContext = inMemoryDataContext;
            EventService = eventService;
        }

        public EventService EventService { get; }
        public InMemoryDataContext InMemoryDataContext { get; }

        public static EventServiceContext GivenContext()
        {
            var inMemoryDataContext = new InMemoryDataContext();
            var repository = new Repository(inMemoryDataContext);
            var eventService = new EventService(repository);
            var fixture = new Fixture();

            return new EventServiceContext(inMemoryDataContext, repository, eventService, fixture);
        }

        public Event WithSingleEvent(Guid ownerId)
        {
            var @event = Fixture
                .Build<Event>()
                .With(x => x.Date, DateTime.Now.AddDays(3))
                .With(x => x.OwnerId, ownerId.ToString())
                .Create();
            InMemoryDataContext.Add(@event);
            InMemoryDataContext.Commit();

            return @event;
        }
    }
}