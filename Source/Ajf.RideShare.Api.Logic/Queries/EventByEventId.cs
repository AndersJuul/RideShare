using System.Linq;
using Ajf.RideShare.Models;
using Highway.Data;

namespace Ajf.RideShare.Api.Logic.Queries
{
    public class EventByEventId:Scalar<Event>
    {
        public EventByEventId(string eventId)
        {
            ContextQuery= 
                context=> context.AsQueryable<Event>().Single(x => x.EventId.ToString() == eventId);
        }
    }
}