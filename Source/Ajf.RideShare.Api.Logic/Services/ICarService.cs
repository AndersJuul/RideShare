using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Logic.Services
{
    public interface ICarService
    {
        Car CreateCarForEvent(string ownerId, CarForCreation carForCreation);
    }
}