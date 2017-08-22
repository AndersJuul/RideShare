using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ajf.Nuget.Logging;
using Ajf.RideShare.Models;
using Ajf.RideShare.Web.Models.Home;
using AutoMapper;
using Serilog;

namespace Ajf.RideShare.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Log.Logger = StandardLoggerConfigurator.GetEnrichedLogger();
            Log.Logger.Information("Starting...");

            Mapper.Initialize(config =>
            {
                config.CreateMap<Event, EventViewModel>();
                config.CreateMap<Event, EventDetailsViewModel>();
            });

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
