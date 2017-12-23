//using System.Linq;
//using System.Security.Claims;
//using System.Web.Mvc;
//using Serilog;

//namespace Ajf.RideShare.Web
//{
//    public class LoggingFilterAttribute : ActionFilterAttribute
//    {
//        private readonly string[] _whitelist={"given_name","email", "family_name", "role" ,"sub"};

//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            var info = filterContext.RequestContext.HttpContext.Request.Url.ToString();
//            if (filterContext.RequestContext.HttpContext.User != null)
//            {
//                if (filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
//                {
//                    //info += "|" + filterContext.RequestContext.HttpContext.User.Identity.Name;

//                    var claimsIdentity = filterContext.RequestContext.HttpContext.User.Identity as ClaimsIdentity;
//                    if (claimsIdentity != null)
//                    {
//                        foreach (var claimsIdentityClaim in claimsIdentity.Claims)
//                        {
//                            if (_whitelist.Contains(claimsIdentityClaim.Type))
//                            {
//                                info += $";{claimsIdentityClaim.Type}={claimsIdentityClaim.Value}";
//                            }
//                        }
//                    }
//                }
//            }
//            Log.Logger.Debug("Request: " + info);
//            base.OnActionExecuting(filterContext);
//        }
//    }
//}