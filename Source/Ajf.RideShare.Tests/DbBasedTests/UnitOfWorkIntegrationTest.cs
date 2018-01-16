//using System;
//using System.Linq;
//using Ajf.RideShare.Api.Repositories;
//using Ajf.RideShare.Api.UnitOfWork.Cars;
//using Ajf.RideShare.Api.UnitOfWork.Events;
//using Ajf.RideShare.Models;
//using NUnit.Framework;
//using Ploeh.AutoFixture;

//namespace Ajf.RideShare.Tests.DbBasedTests
//{
//    [TestFixture]
//    [Category("Database")]
//    public class UnitOfWorkIntegrationTest : IntegrationTestBase
//    {
//        [Test]
//        public void ThatCreateCarCreatesACar()
//        {
//            var dbContextProvider = new DbTestContextProvider(ConnectionString);

//            var anyEvent = DbContext.Events.First();

//            var before = DbContext.Cars.Count();

//            using (var sut = new CreateCarForEvent(Guid.NewGuid().ToString(), new CarRepository(dbContextProvider)))
//            {
//                var carForCreation = new Fixture()
//                    .Build<CarForCreation>()
//                    .With(x=>x.EventId, anyEvent.EventId)
//                    .Create();
//                sut.Execute(carForCreation);
//            }

//            var after = DbContext.Cars.Count();

//            Assert.That((after - before).Equals(1));
//        }

//        [Test]
//        public void ThatCreateEventCreatesAnEvent()
//        {
//            var dbContextProvider = new DbTestContextProvider(ConnectionString);

//            var before = DbContext.Events.Count();

//            using (var sut = new CreateEvent(Guid.NewGuid().ToString(), new EventRepository(dbContextProvider)))
//            {
//                var eventForCreation = new Fixture().Build<EventForCreation>().Create();
//                sut.Execute(eventForCreation);
//            }

//            var after = DbContext.Events.Count();

//            Assert.That((after - before).Equals(1));
//        }
//    }
//}