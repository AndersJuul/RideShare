using System;
using Ajf.RideShare.Api.Logic.Services;
using Ajf.RideShare.Models;
using Highway.Data;
using Highway.Data.Contexts;
using Ploeh.AutoFixture;

namespace Ajf.RideShare.Tests.UnitTests
{
    public class EventServiceContext
    {
        public IRepository Repository { get; }
        public EventService Sut { get; }
        public Fixture Fixture { get;  }

        private EventServiceContext(InMemoryDataContext inMemoryDataContext, IRepository repository,
            EventService eventService, Fixture fixture)
        {
            InMemoryDataContext = inMemoryDataContext;
            Repository = repository;
            Sut = eventService;
            Fixture = fixture;
        }

        public static EventServiceContext GivenContext()
        {
            var inMemoryDataContext = new InMemoryDataContext();
            var repository = new Repository(inMemoryDataContext);
            var eventService = new EventService(repository);
           
            return new EventServiceContext(inMemoryDataContext, repository,eventService, new Fixture());
        }

        public EventServiceContext WithSingleEvent(Guid ownerId)
        {
            var eventServiceContext = new EventServiceContext(InMemoryDataContext, Repository, Sut, Fixture);

            var @event = eventServiceContext
                .Fixture
                .Build<Event>()
                .With(x => x.Date, DateTime.Now.AddDays(3))
                .With(x=>x.OwnerId, ownerId.ToString())
                .Create();
            InMemoryDataContext.Add(@event);
            InMemoryDataContext.Commit();

            return eventServiceContext;
        }

        public InMemoryDataContext InMemoryDataContext { get; set; }
    }
}