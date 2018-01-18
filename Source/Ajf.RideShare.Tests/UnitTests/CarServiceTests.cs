using System;
using System.Linq.Dynamic;
using Ajf.RideShare.Api.Logic.Queries;
using Ajf.RideShare.Models;
using Ajf.RideShare.Tests.UnitTests.Contexts;
using AutoFixture;
using NUnit.Framework;

namespace Ajf.RideShare.Tests.UnitTests
{
    [TestFixture]
    public class CarServiceTests
    {
        [Test]
        public void ThatServiceCreatesCar()
        {
            // Arrange
            var ownerId=Guid.NewGuid();
            var context = CarServiceContext.GivenContext();
            var singleEvent = context.WithSingleEvent(ownerId);
            var before = context.Repository.Find(new GetCars()).Count();
            var carForCreation = context
                .Fixture
                .Build<CarForCreation>()
                .With(x=>x.EventId, singleEvent.EventId)
                .Create();

            // Act
            context.CarService.CreateCarForEvent(ownerId.ToString(), carForCreation);

            // Assert
            var after = context.Repository.Find(new GetCars()).Count();
            Assert.That((after - before).Equals(1));
        }

        //[Test]
        //public void ThatServiceReturnsEventsByOwnerId()
        //{
        //    // Arrange
        //    var ownerId = Guid.NewGuid();
        //    var context = CarServiceContext.GivenContext();
        //    WithSingleEvent(ownerId);

        //    // Act
        //    var events = context.Sut.GetEvents(ownerId.ToString());

        //    // Assert
        //    Assert.AreEqual(1, events.Count());
        //}
    }
}