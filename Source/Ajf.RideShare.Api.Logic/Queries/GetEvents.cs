using Ajf.RideShare.Models;
using Highway.Data;

namespace Ajf.RideShare.Api.Logic.Queries
{
    public class GetEvents : Query<Event>
    {
        public GetEvents()
        {
            ContextQuery = context => context.AsQueryable<Event>();
        }
    }
}