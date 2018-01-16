//using Ajf.RideShare.Models;

//namespace Ajf.RideShare.Api.Repositories
//{
//    public class CarRepository : ICarRepository
//    {
//        private readonly IDbContextProvider _dbContextProvider;

//        public CarRepository(IDbContextProvider dbContextProvider)
//        {
//            _dbContextProvider = dbContextProvider;
//        }

//        public void AddCar(Car car)
//        {
//            using (var db = _dbContextProvider.GetContext())
//            {
//                db.Cars.Add(car);

//                db.SaveChanges();
//            }
//        }
//    }
//}