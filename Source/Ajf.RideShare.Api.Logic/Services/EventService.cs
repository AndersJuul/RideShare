using System;
using System.Collections.Generic;
using System.Linq;
using Ajf.RideShare.Api.Logic.Queries;
using Ajf.RideShare.Models;
using Highway.Data;

namespace Ajf.RideShare.Api.Logic.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository _repository;

        public EventService(IRepository repository)
        {
            _repository = repository;
        }

        public Event GetSingleEvent(string eventId)
        {
            var single = _repository.Find(new EventByEventId(eventId));

            // return a dto
            return single;
        }

        public IEnumerable<Event> GetEvents(string ownerId)
        {
            var events = _repository.Find(new EventsByOwnerAndDate(ownerId, DateTime.Today, 5));

            // return a dto
            return events.ToArray();
        }

        public Event AddEvent(Event @event)
        {
            _repository.Context.Add(@event);

            _repository.Context.Commit();

            return @event;
        }

        public Event UpdateEvent(Event @event)
        {
            var single = _repository.Find(new EventByEventId(@event.EventId.ToString()));
                
            single.Date = @event.Date;
            single.Description = @event.Description;

            _repository.Context.Commit();

            return @event;
        }
    }
}