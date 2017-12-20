using System;
using System.Collections.Generic;
using Ajf.RideShare.Models;
using Serilog;
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
            Log.Logger.Debug("UOW.GetEvents.Execute(1)");

            if (string.IsNullOrEmpty( _ownerId))
            {
                Log.Logger.Debug("UOW.GetEvents.Execute(2)");
                return new UnitOfWorkResult<IEnumerable<Event>>(null, UnitOfWorkStatus.Invalid);
            }

            if (_ownerId == null)
            {
                Log.Logger.Debug("UOW.GetEvents.Execute(3)");
                return new UnitOfWorkResult<IEnumerable<Event>>(null, UnitOfWorkStatus.Forbidden);
            }

            Log.Logger.Debug("UOW.GetEvents.Execute(4)");
            var events = _eventRepository.GetEvents(_ownerId);

            // return a dto
            Log.Logger.Debug("UOW.GetEvents.Execute(5)");
            return new UnitOfWorkResult<IEnumerable<Event>>(events, UnitOfWorkStatus.Ok);
        }
    }
}