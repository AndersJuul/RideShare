using System;
using Ajf.RideShare.Models;
using AutoMapper;
using Highway.Data;

namespace Ajf.RideShare.Api.Logic.Services
{
    public class CarService : ICarService
    {
        public CarService(IRepository repository)
        {
            Repository = repository;
        }

        public IRepository Repository { get; }

        public Car CreateCarForEvent(string ownerId, CarForCreation carForCreation)
        {
            // map to entity
            var car = Mapper.Map<CarForCreation, Car>(carForCreation);

            // create guid
            car.CarId = Guid.NewGuid();

            Repository.Context.Add(car);
            Repository.Context.Commit();

            // return a dto
            return car;
        }
    }
}