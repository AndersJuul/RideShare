using System;
using Ajf.RideShare.Models;
using AutoMapper;
using TripGallery.API.UnitOfWork;
using TripGallery.Repository;

namespace Ajf.RideShare.Api.UnitOfWork.Events
{
    public class UpdateEvent : IUnitOfWork<Event, Event>, IDisposable
    {
        private readonly string _ownerId;
        private IEventRepository _eventRepository;

        private UpdateEvent()
        {
            _eventRepository = new EventRepository();
        }

        public UpdateEvent(string ownerId)
            : this()
        {
            _ownerId = ownerId;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public UnitOfWorkResult<Event> Execute(Event @event)
        {
            if (@event == null)
                return new UnitOfWorkResult<Event>(null, UnitOfWorkStatus.Invalid);

            if (_ownerId == null || _ownerId!= @event.OwnerId)
                return new UnitOfWorkResult<Event>(null, UnitOfWorkStatus.Forbidden);

            // create guid
            _eventRepository.UpdateEvent(@event);

            // return a dto
            return new UnitOfWorkResult<Event>(@event, UnitOfWorkStatus.Ok);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_eventRepository != null)
                {
                    _eventRepository.Dispose();
                    _eventRepository = null;
                }
        }
    }
}