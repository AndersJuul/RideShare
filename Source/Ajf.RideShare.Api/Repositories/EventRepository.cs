using System.Collections.Generic;
using System.Linq;
using Ajf.RideShare.Models;
using Serilog;

namespace Ajf.RideShare.Api.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbContextProvider _dbContextProvider;

        public EventRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public void InsertEvent(Event @event)
        {
            using (var db = _dbContextProvider.GetContext())
            {
                db.Events.Add(@event);

                db.SaveChanges();
            }
        }

        public IEnumerable<Event> GetEvents(string ownerId)
        {
            Log.Logger.Debug("EventRepository.GetEvents.Execute(4)");

            using (var db = _dbContextProvider.GetContext())
            {
                return db
                    .Events
                    .Where(x=>x.OwnerId==ownerId)
                    .ToArray();
            }
        }

        public void UpdateEvent(Event @event)
        {
            using (var db = _dbContextProvider.GetContext())
            {
                var single = db.Events.Single(x=>x.EventId==@event.EventId);

                single.Date = @event.Date;
                single.Description = @event.Description;

                db.SaveChanges();
            }
        }

        public Event GetSingleEvent(string eventId)
        {
            using (var db = _dbContextProvider.GetContext())
            {
                var single = db.Events.Single(x => x.EventId.ToString() == eventId);

                return single;
            }
        }
    }
}