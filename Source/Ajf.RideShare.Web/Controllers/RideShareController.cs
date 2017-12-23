using System.Web.Mvc;
using Ajf.Nuget.Logging;

namespace Ajf.RideShare.Web.Controllers
{
    [LoggingFilter]
    public abstract class RideShareController:Controller
    {
    }
}