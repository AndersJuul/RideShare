using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ajf.RideShare.Api.Controllers
{
    [Authorize]
    [EnableCors("https://localhost:44316", "*", "GET, POST, DELETE")]
    public class EventsController : ApiController
    {
        [Route("api/Events/{sub}")]
        public async Task<IHttpActionResult> Get(string sub)
        {
            return Ok(new[] {"A", "B"});
        }
    }
}