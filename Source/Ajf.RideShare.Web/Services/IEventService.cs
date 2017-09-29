using Ajf.RideShare.Web.Models.ApiModels;

namespace Ajf.RideShare.Web.Services
{
    public interface IEventService
    {
        Event[] GetEvents();
    }
}