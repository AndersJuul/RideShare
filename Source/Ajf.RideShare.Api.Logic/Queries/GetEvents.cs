using Ajf.RideShare.Models;
using Highway.Data;

namespace Ajf.RideShare.Tests.DbBasedTests
{
    public class GetEvents:Query<Event>
    {
        public GetEvents()
        {
            ContextQuery = context => context.AsQueryable<Event>();
        }
    }
}