using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Repositories
{
    public interface IDbContextProvider
    {
        ApplicationDbContext GetContext();
    }
}