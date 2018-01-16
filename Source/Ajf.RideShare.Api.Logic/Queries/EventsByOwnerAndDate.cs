using System;
using System.Linq;
using Ajf.RideShare.Models;
using Highway.Data;

namespace Ajf.RideShare.Api.Logic.Queries
{
    public class EventsByOwnerAndDate : Query<Event>
    {
        public EventsByOwnerAndDate(string ownerId, DateTime dateTime, int maxCount)
        {
            ContextQuery =
                context => context.AsQueryable<Event>()
                    .Where(x => x.OwnerId == ownerId)
                    .Where(x => x.Date > DateTime.Today)
                    .OrderBy(x => x.Date)
                    .Take(5);
        }
    }
}