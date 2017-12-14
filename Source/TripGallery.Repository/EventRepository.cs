using System;
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

        //public void SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}
    }
}