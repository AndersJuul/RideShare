using System.Linq;
using Ajf.RideShare.Api.Logic.Services;
using Ajf.RideShare.Models;
using Ajf.RideShare.Tests.DbBasedTests;
using Highway.Data;
using Highway.Data.Contexts;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Ajf.RideShare.Tests.UnitTests
{
    [TestFixture]
    public class EventServiceTests:BaseUnitTests
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }
        [Test]
        public void ThatServiceCreatesEvent()
        {
            var inMemoryDataContext = new InMemoryDataContext();

            var repository = new Repository(inMemoryDataContext);
            var before = repository.Find(new GetEvents()).Count();

            var sut = new EventService(repository);
            var @event = new Fixture().Build<Event>().Create();

            sut.AddEvent(@event);

            var after = repository.Find(new GetEvents()).Count();

            Assert.That((after - before).Equals(1));
        }

        [Test]
        public void ThatServicePassesGetResultFromRepository()
        {
            //// Arrange
            //var eventRepository = MockRepository.GenerateMock<IEventRepository>();
            //var events = _fixture.CreateMany<Event>().ToArray();
            //eventRepository.Expect(x => x.GetEvents()).Return(events);
            //var eventService = new EventService(eventRepository);

            //// Act
            //var result = eventService.GetEvents();

            //// Assert
            //Assert.AreEqual(events, result);
        }
    }
}