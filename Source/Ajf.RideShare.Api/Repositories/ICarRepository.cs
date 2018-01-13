using System;
using Ajf.RideShare.Models;

namespace TripGallery.Repository
{
    public interface ICarRepository:IDisposable
    {
        void AddCar(Car car);
    }
}