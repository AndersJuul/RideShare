using System.Web.Mvc;
using Serilog;

namespace Ajf.RideShare.Web
{
    public class CachingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var info = filterContext.RequestContext.HttpContext.Request.Url.ToString();
            if (filterContext.RequestContext.HttpContext.User != null)
            {
                info += "|" + filterContext.RequestContext.HttpContext.User.Identity.Name;
            }
            Log.Logger.Debug("Request: " + info);
            base.OnActionExecuting(filterContext);
        }
    }
}