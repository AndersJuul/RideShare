using System;
using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Repositories
{
    public interface ICarRepository:IDisposable
    {
        void AddCar(Car car);
    }
}