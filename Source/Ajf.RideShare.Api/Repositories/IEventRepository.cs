using System;
using System.Collections.Generic;
using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.Repositories
{
    public interface IEventRepository:IDisposable
    {
        void InsertEvent(Event @event);
        IEnumerable<Event> GetEvents(string ownerId);
        void UpdateEvent(Event @event);
        Event GetSingleEvent(string eventId);
    }
}