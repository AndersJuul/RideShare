using Ajf.RideShare.Models;
using Highway.Data;

namespace Ajf.RideShare.Api.Logic.Queries
{
    public class GetCars : Query<Car>
    {
        public GetCars()
        {
            ContextQuery = context => context.AsQueryable<Car>();
        }
    }
}