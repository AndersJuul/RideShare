using System;
using Ajf.RideShare.Models;
using AutoMapper;

namespace Ajf.RideShare.Api.Logic.Services
{
    public class CarService : ICarService
    {
        public Car CreateCarForEvent(string ownerId, CarForCreation carForCreation)
        {
            // map to entity
            var car = Mapper.Map<CarForCreation, Car>(carForCreation);

            // create guid
            car.CarId = Guid.NewGuid();

            using (var db = new ApplicationDbContext())
            {
                db.Cars.Add(car);

                db.SaveChanges();
            }

            // return a dto
            return car;
        }
    }
}