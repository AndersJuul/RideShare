using System.Web.Mvc;
using Serilog;

namespace Ajf.RideShare.Web.Controllers
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           Log.Logger. Information("(Logging Filter)Action Executing: " +filterContext.ActionDescriptor.ActionName);

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
                Log.Logger.Error(filterContext.Exception, "(Logging Filter)Exception thrown");

            base.OnActionExecuted(filterContext);
        }
    }
}