using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ajf.Nuget.Logging;
using Ajf.RideShare.Models;
using Ajf.RideShare.Web.Models.ViewModels.Home;
using AutoMapper;
using Serilog;
using WebApi.StructureMap;

namespace Ajf.RideShare.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Log.Logger = StandardLoggerConfigurator.GetEnrichedLogger();
            Log.Logger.Information("Starting...");

            GlobalConfiguration
                .Configuration
                .UseStructureMap(x => { x.AddRegistry<WebRegistry>(); });

            Mapper.Initialize(config =>
            {
                config.CreateMap<Event, EventViewModel>();
                config.CreateMap<Event, EventDetailsViewModel>();
                config.CreateMap<Event, Models.ApiModels.Event>();
            });

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(x=> WebApiConfig.Register(x));
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}