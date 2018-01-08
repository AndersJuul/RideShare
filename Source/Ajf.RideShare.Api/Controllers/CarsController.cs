using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Ajf.RideShare.Api.Helpers;
using Ajf.RideShare.Api.UnitOfWork;
using Ajf.RideShare.Api.UnitOfWork.Cars;
using Ajf.RideShare.Models;
using Serilog;
using TripGallery.Repository;

namespace Ajf.RideShare.Api.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "GET, POST, DELETE")]
    public class CarsController : RideShareApiController
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [Route("api/Cars")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CarForCreation carForCreation)
        {
            try
            {
                await Task.FromResult(0);

                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                using (var uow = new CreateCarForEvent(ownerId, _carRepository))
                {
                    var uowResult = uow.Execute(carForCreation);

                    switch (uowResult.Status)
                    {
                        case UnitOfWorkStatus.Ok:
                            return Created
                                (Request.RequestUri + "/" + uowResult.Result.CarId, uowResult.Result);

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
                Log.Logger.Error(ex, "During CarsController.Post");
                return InternalServerError();
            }
        }
    }
}