using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Ajf.RideShare.Api.Helpers;
using Ajf.RideShare.Api.UnitOfWork;
using TripGallery.API.Helpers;
using TripGallery.API.UnitOfWork.Picture;

namespace Ajf.RideShare.Api.Controllers
{
    [Authorize]
    [EnableCors("https://localhost:44316", "*", "GET, POST, DELETE")]
    public class PicturesController : RideShareApiController
    {

        [Route("api/trips/{tripId}/pictures")]
        [HttpGet]
        public IHttpActionResult Get(Guid tripId)
        {
            try
            {
                string ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                using (var uow = new GetPictures(ownerId, tripId))
                {
                    var uowResult = uow.Execute();

                    switch (uowResult.Status)
                    {
                        case UnitOfWorkStatus.Ok:
                            return Ok(uowResult.Result);

                        case UnitOfWorkStatus.NotFound:
                            return NotFound();

                        case UnitOfWorkStatus.Forbidden:
                            return StatusCode(HttpStatusCode.Forbidden);

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

   
        [Route("api/trips/{tripId}/pictures")]
        [HttpPost]
        public IHttpActionResult Post(Guid tripId, [FromBody]TripGallery.DTO.PictureForCreation pictureForCreation)
        {
            try
            {

                string ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                using (var uow = new CreatePicture(ownerId, tripId))
                {
                    var uowResult = uow.Execute(pictureForCreation);

                    switch (uowResult.Status)
                    {
                        case UnitOfWorkStatus.Ok:
                            return Created<TripGallery.DTO.Picture>
                            (Request.RequestUri + "/" + uowResult.Result.Id.ToString(), uowResult.Result);
                            
                        case UnitOfWorkStatus.Invalid:
                            return BadRequest();

                        case UnitOfWorkStatus.NotFound:
                            return NotFound();

                        case UnitOfWorkStatus.Forbidden:
                            return StatusCode(HttpStatusCode.Forbidden);

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


        // TODO: is the user allowed to delete?
        [Route("api/trips/{tripId}/pictures/{pictureId}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid tripId, Guid pictureId)
        {
            try
            {
                // the user can delete.  But can he also delete THIS picture?
                string ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                using (var uow = new DeletePicture(ownerId, tripId, pictureId))
                {
                    var uowResult = uow.Execute();

                    switch (uowResult.Status)
                    {
                        case UnitOfWorkStatus.Ok:
                            return StatusCode(HttpStatusCode.NoContent);

                        case UnitOfWorkStatus.Invalid:
                            return BadRequest();

                        case UnitOfWorkStatus.NotFound:
                            return NotFound();

                        case UnitOfWorkStatus.Forbidden:
                            return StatusCode(HttpStatusCode.Forbidden);
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
    }
}
