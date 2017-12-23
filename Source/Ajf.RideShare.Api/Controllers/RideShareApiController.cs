using System.Web.Http;
using Ajf.Nuget.Logging;

namespace Ajf.RideShare.Api.Controllers
{
    [LoggingFilter]
    public abstract class RideShareApiController:ApiController
    {
    }
}