using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Logic
{
    public class DbContextProvider : IDbContextProvider
    {
        public ApplicationDbContext GetContext()
        {
            return new ApplicationDbContext();
        }
    }
}