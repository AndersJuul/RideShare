using System.Linq;
using Ajf.RideShare.Models;
using AutoMapper;
using Event = Ajf.RideShare.Web.Models.ApiModels.Event;

namespace Ajf.RideShare.Web.Repositories
{
    public class EventRepository : IEventRepository
    {
        public Event[] GetEvents()
        {
            using (var context = new ApplicationDbContext())
            {
                var contextEvents = context
                    .Events.ToArray();
                var queryable = contextEvents
                    .Select(Mapper.Map<Models.ApiModels.Event>);
                var events = queryable
                    .ToArray();

                return events;
            }
        }
    }
}