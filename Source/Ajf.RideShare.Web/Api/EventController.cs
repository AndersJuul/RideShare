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
        //[Authorize(Roles= "RideShare.Events.Read")]
        [Authorize]
        public Event[] Get()
        {
            return _eventService
                .GetEvents();
        }
    }
}