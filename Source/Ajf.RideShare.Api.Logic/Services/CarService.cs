using System;
using Ajf.RideShare.Models;
using AutoMapper;

namespace Ajf.RideShare.Api.Logic.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CarService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Car CreateCarForEvent(string ownerId, CarForCreation carForCreation)
        {
            // map to entity
            var car = Mapper.Map<CarForCreation, Car>(carForCreation);

            // create guid
            car.CarId = Guid.NewGuid();

            _applicationDbContext.Cars.Add(car);

            _applicationDbContext.SaveChanges();

            // return a dto
            return car;
        }
    }
}