using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Ajf.RideShare.Api.Helpers;
using Ajf.RideShare.Api.Repositories;
using Ajf.RideShare.Api.UnitOfWork;
using Ajf.RideShare.Api.UnitOfWork.Events;
using Ajf.RideShare.Models;
using Serilog;

namespace Ajf.RideShare.Api.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "GET, POST, DELETE")]
    public class EventsController : RideShareApiController
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
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

                using (var uow = new GetSingleEvent(sub,ownerId, _eventRepository))
                {
                    var uowResult = uow.Execute();

                    switch (uowResult.Status)
                    {
                        case UnitOfWorkStatus.Ok:
                            return Ok(uowResult.Result);

                        default:
                            return InternalServerError();
                    }
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

                using (var uow = new GetActiveEvents(ownerId, _eventRepository))
                {
                    var uowResult = uow.Execute();

                    var count = uowResult.Result?.Count() ?? 0;

                    Log.Logger.Debug($"ActiveEvents returned {uowResult.Status} and {count}" );

                    switch (uowResult.Status)
                    {
                        case UnitOfWorkStatus.Ok:
                            return Ok(uowResult.Result);

                        default:
                            return InternalServerError();
                    }
                }
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

                using (var uow = new CreateEvent(ownerId, _eventRepository))
                {
                    var uowResult = uow.Execute(eventForCreation);

                    switch (uowResult.Status)
                    {
                        case UnitOfWorkStatus.Ok:
                            return Created
                                (Request.RequestUri + "/" + uowResult.Result.EventId, uowResult.Result);

                        case UnitOfWorkStatus.Forbidden:
                            return StatusCode(HttpStatusCode.Forbidden);

                        case UnitOfWorkStatus.Invalid:
                            return BadRequest();

                        default:
                            return InternalServerError();
                    }
                }
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

                using (var uow = new UpdateEvent(ownerId,_eventRepository))
                {
                    var uowResult = uow.Execute(@event);

                    switch (uowResult.Status)
                    {
                        case UnitOfWorkStatus.Ok:
                            return Created
                                (Request.RequestUri + "/" + uowResult.Result.EventId, uowResult.Result);

                        case UnitOfWorkStatus.Forbidden:
                            return StatusCode(HttpStatusCode.Forbidden);

                        case UnitOfWorkStatus.Invalid:
                            return BadRequest();

                        default:
                            return InternalServerError();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "During EventsController.Put");
                return InternalServerError();
            }
        }
    }
}