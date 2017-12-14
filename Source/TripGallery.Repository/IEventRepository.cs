using System;
using Ajf.RideShare.Models;

namespace TripGallery.Repository
{
    public interface IEventRepository:IDisposable
    {
        void InsertEvent(Event @event);
        //void SaveChanges();
    }
}