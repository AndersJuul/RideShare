using System;
using System.Collections.Generic;
using Ajf.RideShare.Models;
using TripGallery.API.UnitOfWork;
using TripGallery.Repository;

namespace Ajf.RideShare.Api.UnitOfWork.Events
{
    public class GetEvents : IUnitOfWork<IEnumerable<Event>>, IDisposable
    {
        IEventRepository _eventRepository;
        readonly string _ownerId = null;

        private GetEvents()
        {
            _eventRepository = new EventRepository();
        }

        public GetEvents(string ownerId)
            : this()
        {
            _ownerId = ownerId;
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

        public UnitOfWorkResult<IEnumerable<Event>> Execute()
        {
            if (string.IsNullOrEmpty( _ownerId))
            {
                return new UnitOfWorkResult<IEnumerable<Event>>(null, UnitOfWorkStatus.Invalid);
            }

            if (_ownerId == null)
            {
                // cannot create a trip when there's no owner id
                return new UnitOfWorkResult<IEnumerable<Event>>(null, UnitOfWorkStatus.Forbidden);
            }

            var events = _eventRepository.GetEvents(_ownerId);

            // return a dto
            return new UnitOfWorkResult<IEnumerable<Event>>(events, UnitOfWorkStatus.Ok);
        }
    }
}