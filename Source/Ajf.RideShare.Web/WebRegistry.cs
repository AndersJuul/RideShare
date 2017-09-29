using Ajf.RideShare.Web.Api;
using Ajf.RideShare.Web.Services;
using StructureMap;

namespace Ajf.RideShare.Web
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            For<IEventService>().Use<EventService>();
        }
    }
}