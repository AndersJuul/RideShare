using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace Ajf.RideShare.Api
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "DefaultRouting",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            config.EnableCors(new EnableCorsAttribute("*","*","*"));

            // clear the supported mediatypes of the xml formatter
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("application/json-patch+json"));


            // results should come out
            // - with indentation for readability
            // - in camelCase

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            
            return config;

        }
    }
}
