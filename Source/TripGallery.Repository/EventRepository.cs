using System;
using System.Collections.Generic;
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
    }
}