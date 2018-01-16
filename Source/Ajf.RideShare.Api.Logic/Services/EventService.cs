using System;
using System.Collections.Generic;
using System.Linq;
using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Logic.Services
{
    public class EventService : IEventService
    {
        public Event GetSingleEvent(string eventId)
        {
            using (var db = new ApplicationDbContext())
            {
                var single = db.Events.Single(x => x.EventId.ToString() == eventId);

                // return a dto
                return single;
            }
        }

        public IEnumerable<Event> GetEvents(string ownerId)
        {
            using (var db = new ApplicationDbContext())
            {
                var events = db
                    .Events
                    .Where(x => x.OwnerId == ownerId)
                    .Where(x => x.Date > DateTime.Today)
                    .OrderBy(x => x.Date)
                    .Take(5);

                // return a dto
                return events.ToArray();
            }
        }

        public Event AddEvent(Event @event)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Events.Add(@event);

                db.SaveChanges();

                return @event;
            }
        }

        public Event UpdateEvent(Event @event)
        {
            using (var db = new ApplicationDbContext())
            {
                var single = db.Events.Single(x => x.EventId == @event.EventId);

                single.Date = @event.Date;
                single.Description = @event.Description;

                db.SaveChanges();

                return @event;
            }
        }
    }
}