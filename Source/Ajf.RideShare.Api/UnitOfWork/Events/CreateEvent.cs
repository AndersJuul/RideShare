using System;
using System.Collections.ObjectModel;
using Ajf.RideShare.Models;
using AutoMapper;
using TripGallery.API.UnitOfWork;
using TripGallery.Repository;

namespace Ajf.RideShare.Api.UnitOfWork.Events
{
    public class CreateEvent : IUnitOfWork<Event, EventForCreation>, IDisposable
    {
        private readonly string _ownerId;
        private IEventRepository _eventRepository;

        private CreateEvent()
        {
            _eventRepository = new EventRepository();
        }

        public CreateEvent(string ownerId)
            : this()
        {
            _ownerId = ownerId;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public UnitOfWorkResult<Event> Execute(EventForCreation input)
        {
            if (input == null)
                return new UnitOfWorkResult<Event>(null, UnitOfWorkStatus.Invalid);

            if (_ownerId == null)
                return new UnitOfWorkResult<Event>(null, UnitOfWorkStatus.Forbidden);

            // map to entity
            var @event = Mapper.Map<EventForCreation, Event>(input);

            // create guid
            var id = Guid.NewGuid();
            @event.EventId = id;
            @event.OwnerId = _ownerId;
            @event.Cars=new Collection<Car>();

            _eventRepository.InsertEvent(@event);

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