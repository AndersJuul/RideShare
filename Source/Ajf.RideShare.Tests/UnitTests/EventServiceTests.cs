using System.Linq;
using Ajf.RideShare.Web.Models.ApiModels;
using Ajf.RideShare.Web.Repositories;
using Ajf.RideShare.Web.Services;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Rhino.Mocks;

namespace Ajf.RideShare.Tests.UnitTests
{
    [TestFixture]
    public class EventServiceTests:BaseUnitTests
    {
        [Test]
        public void ThatServicePassesGetResultFromRepository()
        {
            // Arrange
            var eventRepository = MockRepository.GenerateMock<IEventRepository>();
            var events = _fixture.CreateMany<Event>().ToArray();
            eventRepository.Expect(x => x.GetEvents()).Return(events);
            var eventService = new EventService(eventRepository);

            // Act
            var result = eventService.GetEvents();

            // Assert
            Assert.AreEqual(events, result);
        }
    }
}