using Ajf.RideShare.Web.Models.ApiModels;
using Ajf.RideShare.Web.Repositories;

namespace Ajf.RideShare.Web.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event[] GetEvents()
        {
            return _eventRepository.GetEvents();
        }
    }
}