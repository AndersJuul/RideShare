using System.Linq;
using Ajf.RideShare.Models;
using AutoMapper;

namespace Ajf.RideShare.Web.Services
{
    public class EventService : IEventService
    {
        public Models.ApiModels.Event[] GetEvents()
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