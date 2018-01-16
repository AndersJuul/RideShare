//using Ajf.RideShare.Api.Logic;
//using Ajf.RideShare.Models;

//namespace Ajf.RideShare.Tests.DbBasedTests
//{
//    public class DbTestContextProvider : IDbContextProvider
//    {
//        private readonly string _connectionString;

//        public DbTestContextProvider(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public ApplicationDbContext GetContext()
//        {
//            return new ApplicationDbContext
//            {
//                Database =
//                {
//                    Connection =
//                    {
//                        ConnectionString = _connectionString
//                    }
//                }
//            };
//        }
//    }
//}