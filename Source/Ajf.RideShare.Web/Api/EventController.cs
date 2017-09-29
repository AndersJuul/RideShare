using System.Linq;
using System.Web.Http;
using Ajf.RideShare.Models;
using Ajf.RideShare.Web.Services;
using AutoMapper;
using Event = Ajf.RideShare.Web.Models.ApiModels.Event;

namespace Ajf.RideShare.Web.Api
{
    public class EventController : ApiController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET api/<controller>
        public Event[] Get()
        {
            using (var context = new ApplicationDbContext())
            {
                var contextEvents = context
                    .Events.ToArray();
                var queryable = contextEvents
                    .Select(Mapper.Map<Event>);
                var events = queryable
                    .ToArray();

                return events;
            }
        }
    }
}