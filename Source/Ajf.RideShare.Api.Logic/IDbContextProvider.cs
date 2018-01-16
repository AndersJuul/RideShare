using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Logic
{
    public interface IDbContextProvider
    {
        ApplicationDbContext GetContext();
    }
}