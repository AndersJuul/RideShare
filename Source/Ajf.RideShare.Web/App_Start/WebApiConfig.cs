using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace Ajf.RideShare.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Filters.Add(new AddCustomHeaderActionFilterAttribute());
            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class AddCustomHeaderActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            actionExecutedContext.ActionContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            actionExecutedContext.ActionContext.Response.Headers.Add("Access-Control-Allow-Methods","GET, POST, PATCH, PUT, DELETE, OPTIONS");
            actionExecutedContext.ActionContext.Response.Headers.Add("Access-Control-Allow-Headers","Origin, Content-Type, X-Auth-Token");
        }
    }
    //public class AddCustomHeaderFilter : ActionFilterAttribute
    //{
    //    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    //    {
    //        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    //    }
    //}
}
