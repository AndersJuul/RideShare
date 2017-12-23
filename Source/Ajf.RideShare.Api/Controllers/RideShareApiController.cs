using System.Web.Http;
using Ajf.Nuget.Logging;

namespace Ajf.RideShare.Api.Controllers
{
    [ApiLoggingFilter]
    public abstract class RideShareApiController:ApiController
    {
    }
}