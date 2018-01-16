using System.Collections;
using System.Collections.Generic;
using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Controllers
{
    public interface IEventService
    {
        Event GetSingleEvent(string eventId);
        IEnumerable<Event> GetEvents(string ownerId);
        Event AddEvent(Event @event);
        Event UpdateEvent(Event @event);
    }
}