﻿//using System;
//using Ajf.RideShare.Api.Repositories;
//using Ajf.RideShare.Models;
//using AutoMapper;

//namespace Ajf.RideShare.Api.UnitOfWork.Cars
//{
//    public class CreateCarForEvent : IUnitOfWork<Car, CarForCreation>, IDisposable
//    {
//        private readonly string _ownerId;
//        private readonly ICarRepository _carRepository;

//        private CreateCarForEvent(ICarRepository carRepository)
//        {
//            _carRepository = carRepository;
//        }

//        public CreateCarForEvent(string ownerId, ICarRepository carRepository)
//            : this(carRepository)
//        {
//            _ownerId = ownerId;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//        }

//        public UnitOfWorkResult<Car> Execute(CarForCreation input)
//        {
//            if (input == null)
//                return new UnitOfWorkResult<Car>(null, UnitOfWorkStatus.Invalid);

//            // map to entity
//            var car = Mapper.Map<CarForCreation, Car>(input);

//            // create guid
//            car.CarId = Guid.NewGuid();
//            _carRepository.AddCar(car);

//            // return a dto
//            return new UnitOfWorkResult<Car>(car, UnitOfWorkStatus.Ok);
//        }
//    }
//}