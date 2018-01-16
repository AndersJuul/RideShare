using System;
using System.Collections.Generic;
using System.Linq;
using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Logic.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EventService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Event GetSingleEvent(string eventId)
        {
            var single = _applicationDbContext.Events.Single(x => x.EventId.ToString() == eventId);

            // return a dto
            return single;
        }

        public IEnumerable<Event> GetEvents(string ownerId)
        {
            var events = _applicationDbContext
                .Events
                .Where(x => x.OwnerId == ownerId)
                .Where(x => x.Date > DateTime.Today)
                .OrderBy(x => x.Date)
                .Take(5);

            // return a dto
            return events.ToArray();
        }

        public Event AddEvent(Event @event)
        {
            _applicationDbContext.Events.Add(@event);

            _applicationDbContext.SaveChanges();

            return @event;
        }

        public Event UpdateEvent(Event @event)
        {
            var single = _applicationDbContext.Events.Single(x => x.EventId == @event.EventId);

            single.Date = @event.Date;
            single.Description = @event.Description;

            _applicationDbContext.SaveChanges();

            return @event;
        }
    }
}