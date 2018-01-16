using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Repositories
{
    public class DbContextProvider : IDbContextProvider
    {
        public ApplicationDbContext GetContext()
        {
            return new ApplicationDbContext();
        }
    }
}