//using System.Linq;
//using Ajf.RideShare.Api.Logic.Services;
//using Ajf.RideShare.Models;
//using Highway.Data;
//using Highway.Data.Contexts;
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
//                    .With(x => x.EventId, anyEvent.EventId)
//                    .Create();
//                sut.Execute(carForCreation);
//            }

//            var after = DbContext.Cars.Count();

//            Assert.That((after - before).Equals(1));
//        }

//    }
//}