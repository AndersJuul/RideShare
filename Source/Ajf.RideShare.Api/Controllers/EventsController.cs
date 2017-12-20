using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Ajf.RideShare.Api.Helpers;
using Ajf.RideShare.Api.UnitOfWork;
using Ajf.RideShare.Api.UnitOfWork.Events;
using Ajf.RideShare.Models;
using Serilog;

namespace Ajf.RideShare.Api.Controllers
{
    [Authorize]
    [EnableCors("https://localhost:44316", "*", "GET, POST, DELETE")]
    public class EventsController : ApiController
    {
        [Route("api/Events/{sub}")]
        public async Task<IHttpActionResult> GetSingleEvent(string sub)
        {
            try
            {
                await Task.FromResult(0);
                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                using (var uow = new GetSingleEvent(sub,ownerId))
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
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("api/Events/")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                Log.Logger.Debug("api/events/ : Get");
                await Task.FromResult(0);
                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                using (var uow = new GetEvents(ownerId))
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
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("api/Events")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] EventForCreation eventForCreation)
        {
            try
            {
                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                using (var uow = new CreateEvent(ownerId))
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

                using (var uow = new UpdateEvent(ownerId))
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
                return InternalServerError();
            }
        }
    }
}