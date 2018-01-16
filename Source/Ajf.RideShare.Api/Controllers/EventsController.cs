using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Ajf.RideShare.Api.Helpers;
using Ajf.RideShare.Api.Repositories;
using Ajf.RideShare.Models;
using AutoMapper;
using Serilog;

namespace Ajf.RideShare.Api.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "GET, POST, DELETE")]
    public class EventsController : RideShareApiController
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository, IEventService eventService)
        {
            _eventRepository = eventRepository;
        }

        [Route("api/Events/{sub}")]
        public async Task<IHttpActionResult> GetSingleEvent(string sub)
        {
            try
            {
                await Task.FromResult(0);
                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

               if (string.IsNullOrEmpty(ownerId))
                {
                    return StatusCode(HttpStatusCode.Forbidden);
                }

                using (var db = new ApplicationDbContext())
                {
                    var single = db.Events.Single(x => x.EventId.ToString() == sub);

                    // return a dto
                    return Ok(single);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "During EventsController.GetSingleEvent");

                return InternalServerError();
            }
        }

        [Route("api/Events/")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                await Task.FromResult(0);
                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                if (ownerId == null)
                {
                    return StatusCode(HttpStatusCode.Forbidden);
                }

                var events = _eventRepository
                    .GetEvents(ownerId)
                    .Where(x => x.Date > DateTime.Today)
                    .OrderBy(x => x.Date)
                    .Take(5);

                // return a dto
                return Ok(events);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex,"During EventsController.Get");
                return InternalServerError();
            }
        }

        [Route("api/Events")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] EventForCreation eventForCreation)
        {
            try
            {
                await Task.FromResult(0);

                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                if (eventForCreation== null)
                    return BadRequest();

                if (ownerId == null)
                    return StatusCode(HttpStatusCode.Forbidden);

                // map to entity
                var @event = Mapper.Map<EventForCreation, Event>(eventForCreation);

                // create guid
                var id = Guid.NewGuid();
                @event.EventId = id;
                @event.OwnerId = ownerId;
                @event.Cars = new Collection<Car>();

                _eventRepository.InsertEvent(@event);

                // return a dto
                return Ok(@event);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "During EventsController.Post");
                return InternalServerError();
            }
        }

        [Route("api/Events/{eventId}")]
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Event @event)
        {
            try
            {
                await Task.FromResult(0);
                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();


                if (@event == null)
                    return BadRequest();

                if (ownerId == null || ownerId != @event.OwnerId)
                    return Unauthorized();

                // create guid
                _eventRepository.UpdateEvent(@event);

                // return a dto
                return Ok(@event);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "During EventsController.Put");
                return InternalServerError();
            }
        }
    }

}