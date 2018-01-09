using System;
using Ajf.RideShare.Models;
using TripGallery.Repository;

namespace Ajf.RideShare.Api.UnitOfWork.Events
{
    public class GetSingleEvent : IUnitOfWork<Event>, IDisposable
    {
        IEventRepository _eventRepository;
        private readonly string _eventId;
        readonly string _ownerId = null;

        private GetSingleEvent()
        {
            _eventRepository = new EventRepository();
        }

        public GetSingleEvent(string eventId, string ownerId)
            : this()
        {
            _eventId = eventId;
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

        public UnitOfWorkResult<Event> Execute()
        {
            if (string.IsNullOrEmpty(_ownerId))
            {
                return new UnitOfWorkResult<Event>(null, UnitOfWorkStatus.Invalid);
            }

            if (_ownerId == null)
            {
                // cannot create a trip when there's no owner id
                return new UnitOfWorkResult<Event>(null, UnitOfWorkStatus.Forbidden);
            }

            var events = _eventRepository.GetSingleEvent(_eventId);

            // return a dto
            return new UnitOfWorkResult<Event>(events, UnitOfWorkStatus.Ok);
        }
    }
}