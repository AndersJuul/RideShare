using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Ajf.RideShare.Api.Helpers;
using Ajf.RideShare.Api.UnitOfWork;
using Ajf.RideShare.Api.UnitOfWork.Events;
using Ajf.RideShare.Models;
using TripGallery.API.UnitOfWork.Trip;

namespace Ajf.RideShare.Api.Controllers
{
    [Authorize]
    [EnableCors("https://localhost:44316", "*", "GET, POST, DELETE")]
    public class EventsController : ApiController
    {
        [Route("api/Events/{sub}")]
        public async Task<IHttpActionResult> Get(string sub)
        {
                try
                {
                    string ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

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
        public async Task<IHttpActionResult> Post([FromBody]EventForCreation eventForCreation)
        {
            try
            {
                string ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                using (var uow = new CreateEvent(ownerId))
                {
                    var uowResult = uow.Execute(eventForCreation);

                    switch (uowResult.Status)
                    {
                        case UnitOfWork.UnitOfWorkStatus.Ok:
                            return Created<Event>
                                (Request.RequestUri + "/" + uowResult.Result.EventId, uowResult.Result);

                        case UnitOfWork.UnitOfWorkStatus.Forbidden:
                            return StatusCode(HttpStatusCode.Forbidden);

                        case UnitOfWork.UnitOfWorkStatus.Invalid:
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