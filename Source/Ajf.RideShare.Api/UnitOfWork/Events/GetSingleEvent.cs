using System;
using Ajf.RideShare.Api.Repositories;
using Ajf.RideShare.Models;

namespace Ajf.RideShare.Api.UnitOfWork.Events
{
    public class GetSingleEvent : IUnitOfWork<Event>, IDisposable
    {
        readonly IEventRepository _eventRepository;
        private readonly string _eventId;
        readonly string _ownerId;

        public GetSingleEvent(string eventId, string ownerId, IEventRepository eventRepository)
        {
            _eventId = eventId;
            _ownerId = ownerId;
            _eventRepository = eventRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
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