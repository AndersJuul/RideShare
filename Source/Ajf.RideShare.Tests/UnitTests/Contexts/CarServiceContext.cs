using Ajf.RideShare.Api.Logic;
using Ajf.RideShare.Api.Logic.Services;
using AutoFixture;
using Highway.Data;
using Highway.Data.Contexts;

namespace Ajf.RideShare.Tests.UnitTests.Contexts
{
    public class CarServiceContext: EventServiceContext
    {
        public ICarService CarService { get; }

        public new static CarServiceContext GivenContext()
        {
            AutoMapperInitializor.Init();

            var inMemoryDataContext = new InMemoryDataContext();
            var repository = new Repository(inMemoryDataContext);
            var eventService = new EventService(repository);
            var carService = new CarService(repository);
            var fixture = new Fixture();

            return new CarServiceContext(fixture,repository,carService,  inMemoryDataContext, eventService);
        }

        public CarServiceContext(Fixture fixture, IRepository repository, ICarService carService,
            InMemoryDataContext inMemoryDataContext, EventService eventService) : base(inMemoryDataContext,repository,eventService,fixture)
        {
            CarService = carService;
        }
    }
}