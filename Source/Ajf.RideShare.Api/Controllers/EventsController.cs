using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Ajf.RideShare.Api.Helpers;
using Ajf.RideShare.Api.Logic.Services;
using Ajf.RideShare.Models;
using AutoMapper;
using Serilog;

namespace Ajf.RideShare.Api.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "GET, POST, DELETE")]
    public class EventsController : RideShareApiController
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Route("api/Events/{sub}")]
        public async Task<IHttpActionResult> GetSingleEvent(string sub)
        {
            try
            {
                await Task.FromResult(0);
                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                if (string.IsNullOrEmpty(ownerId)) return StatusCode(HttpStatusCode.Forbidden);

                var @event = _eventService.GetSingleEvent(sub);

                // return a dto
                return Ok(@event);
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

                if (ownerId == null) return StatusCode(HttpStatusCode.Forbidden);

                Log.Logger.Debug("EventRepository.GetEvents.Execute(4)");

                var events = _eventService.GetEvents(ownerId);
                
                    // return a dto
                    return Ok(events);
                
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "During EventsController.Get");
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

                if (eventForCreation == null)
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

                var addedEvent = _eventService.AddEvent(@event);

                // return a dto
                return Ok(addedEvent);
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

                var updatedEvent = _eventService.UpdateEvent(@event);

                // return a dto
                return Ok(updatedEvent);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "During EventsController.Put");
                return InternalServerError();
            }
        }
    }
}