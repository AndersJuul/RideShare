using Ajf.RideShare.Web.Models.ApiModels;

namespace Ajf.RideShare.Web.Repositories
{
    public interface IEventRepository
    {
        Event[] GetEvents();
    }
}