using System;
using System.IO;
using Ajf.RideShare.Models;
using AutoMapper;
using TripGallery.API.UnitOfWork;
using TripGallery.DTO;
using TripGallery.Repository;
using TripGallery.Repository.Entities;
using Trip = TripGallery.DTO.Trip;

namespace Ajf.RideShare.Api.UnitOfWork.Events
{
    public class CreateEvent : IUnitOfWork<Event, EventForCreation>, IDisposable
    {

        IEventRepository _eventRepository;
        readonly string _ownerId = null;
     
        private CreateEvent()
        {
           _eventRepository = new EventRepository();
        }
    
        public CreateEvent(string ownerId)
            : this()
        {
            _ownerId = ownerId;
        }


        public UnitOfWorkResult<Event> Execute(EventForCreation input)
        {          
            if (input == null)
            {
                return new UnitOfWorkResult<Event>(null, UnitOfWorkStatus.Invalid);
            }

            if (_ownerId == null)
            {
                // cannot create a trip when there's no owner id
                return new UnitOfWorkResult<Event>(null, UnitOfWorkStatus.Forbidden);
            }
            // map to entity
            var @event = Mapper.Map<EventForCreation, Event>(input);

            // create guid
            var id = Guid.NewGuid();
            @event.EventId = id;
            @event.OwnerId = _ownerId;

   
            _eventRepository.InsertEvent(@event);

            // commit
            //_eventRepository.SaveChanges();
            
            // return a dto
            var dto = Mapper.Map<Event, Event>(@event);
            return new UnitOfWorkResult<Event>(dto, UnitOfWorkStatus.Ok);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_eventRepository != null)
                {
                    _eventRepository.Dispose();
                    _eventRepository = null;
                } 
            }
        }

    }
}
