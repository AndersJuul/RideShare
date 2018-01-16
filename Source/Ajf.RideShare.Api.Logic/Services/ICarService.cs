using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Controllers
{
    public interface ICarService
    {
        Car CreateCarForEvent(string ownerId, CarForCreation carForCreation);
    }
}