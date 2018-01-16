using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using Ajf.RideShare.Api.Helpers;

namespace Ajf.RideShare.Api.Controllers
{
    //[Authorize]
    [EnableCors("https://localhost:44316", "*", "GET, POST, PATCH")]
    public class UserInfoController : RideShareApiController
    {
        //[Authorize(Roles = "PayingUser")]
        [Route("api/userinfo")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Dictionary<string,string> claimsIdentity)
        {
            try
            {
                var ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

                //using (var uow = new CreateEvent(ownerId))
                //{
                //    var uowResult = uow.Execute(tripForCreation);

                //    switch (uowResult.Status)
                //    {
                //        case UnitOfWorkStatus.Ok:
                //            return Created
                //                (Request.RequestUri + "/" + uowResult.Result.Id, uowResult.Result);

                //        case UnitOfWorkStatus.Forbidden:
                //            return StatusCode(HttpStatusCode.Forbidden);

                //        case UnitOfWorkStatus.Invalid:
                //            return BadRequest();

                //        default:
                //            return InternalServerError();
                //    }
                //}
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}