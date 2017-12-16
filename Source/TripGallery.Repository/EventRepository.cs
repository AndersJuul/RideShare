using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Ajf.RideShare.Models;

namespace TripGallery.Repository
{
    public class EventRepository : IEventRepository
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void InsertEvent(Event @event)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Events.Add(@event);

                db.SaveChanges();
            }
        }

        public IEnumerable<Event> GetEvents(string ownerId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db
                    .Events
                    .Where(x=>x.OwnerId==ownerId)
                    .ToArray();
            }
        }

        public void UpdateEvent(Event @event)
        {
            using (var db = new ApplicationDbContext())
            {
                var single = db.Events.Single(x=>x.EventId==@event.EventId);

                single.Date = @event.Date;
                single.Description = @event.Description;

                db.SaveChanges();
            }
        }

        public Event GetSingleEvent(string eventId)
        {
            throw new NotImplementedException();
        }
    }
}