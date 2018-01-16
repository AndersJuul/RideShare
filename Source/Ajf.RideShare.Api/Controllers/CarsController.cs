using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Ajf.RideShare.Api.Helpers;
using Ajf.RideShare.Api.Logic.Services;
using Ajf.RideShare.Models;
using Serilog;

namespace Ajf.RideShare.Api.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "GET, POST, DELETE")]
    public class CarsController : RideShareApiController
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [Route("api/Cars")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CarForCreation carForCreation)
        {
            try
            {
                await Task.FromResult(0);

                if (carForCreation == null)
                    return BadRequest();

                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                if (ownerId == null)
                    return StatusCode(HttpStatusCode.Forbidden);

                var car = _carService.CreateCarForEvent(ownerId, carForCreation);

                return Created
                    (Request.RequestUri + "/" + car.CarId, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "During CarsController.Post");
                return InternalServerError();
            }
        }
    }
}