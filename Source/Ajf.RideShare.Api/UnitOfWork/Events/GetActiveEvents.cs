//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Ajf.RideShare.Api.Repositories;
//using Ajf.RideShare.Models;

//namespace Ajf.RideShare.Api.UnitOfWork.Events
//{
//    public class GetActiveEvents : IUnitOfWork<IEnumerable<Event>>, IDisposable
//    {
//        private readonly string _ownerId;
//        private readonly IEventRepository _eventRepository;

//        public GetActiveEvents(string ownerId, IEventRepository eventRepository)            
//        {
//            _ownerId = ownerId;
//            _eventRepository = eventRepository;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        public UnitOfWorkResult<IEnumerable<Event>> Execute()
//        {
//            if (string.IsNullOrEmpty(_ownerId))
//            {
//                return new UnitOfWorkResult<IEnumerable<Event>>(null, UnitOfWorkStatus.Invalid);
//            }

//            if (_ownerId == null)
//            {
//                return new UnitOfWorkResult<IEnumerable<Event>>(null, UnitOfWorkStatus.Forbidden);
//            }

//            var events = _eventRepository
//                .GetEvents(_ownerId)
//                .Where(x => x.Date > DateTime.Today)
//                .OrderBy(x => x.Date)
//                .Take(5);

//            // return a dto
//            return new UnitOfWorkResult<IEnumerable<Event>>(events, UnitOfWorkStatus.Ok);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//        }
//    }
//}