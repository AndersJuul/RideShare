using System;
using Ajf.RideShare.Models;
using AutoMapper;
using TripGallery.Repository;

namespace Ajf.RideShare.Api.UnitOfWork.Cars
{
    public class CreateCarForEvent : IUnitOfWork<Car, CarForCreation>, IDisposable
    {
        private readonly string _ownerId;
        private ICarRepository _carRepository;

        private CreateCarForEvent(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public CreateCarForEvent(string ownerId, ICarRepository carRepository)
            : this(carRepository)
        {
            _ownerId = ownerId;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_carRepository != null)
                {
                    _carRepository.Dispose();
                    _carRepository = null;
                }
        }

        public UnitOfWorkResult<Car> Execute(CarForCreation input)
        {
            if (input == null)
                return new UnitOfWorkResult<Car>(null, UnitOfWorkStatus.Invalid);

            if (_ownerId == null)
                return new UnitOfWorkResult<Car>(null, UnitOfWorkStatus.Forbidden);

            // map to entity
            var car = Mapper.Map<CarForCreation, Car>(input);

            // create guid
            var id = Guid.NewGuid();
            //car.EventId = id;
            //car.OwnerId = _ownerId;
            //car.Cars = new Collection<Car>();

            _carRepository.AddCar(car);

            // return a dto
            return new UnitOfWorkResult<Car>(car, UnitOfWorkStatus.Ok);
        }
    }
}