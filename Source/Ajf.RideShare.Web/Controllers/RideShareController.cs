using System.Web.Mvc;
using Ajf.Nuget.Logging;

namespace Ajf.RideShare.Web.Controllers
{
    [WebLoggingFilter]
    public abstract class RideShareController:Controller
    {
    }
}