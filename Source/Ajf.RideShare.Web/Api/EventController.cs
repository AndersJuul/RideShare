using System.Linq;
using System.Web.Http;
using Ajf.RideShare.Models;
using AutoMapper;

namespace Ajf.RideShare.Web.Api
{
    public class EventController : ApiController
    {
        // GET api/<controller>
        public Models.ApiModels.Event[] Get()
        {
            using (var context = new ApplicationDbContext())
            {
                var contextEvents = context
                    .Events.ToArray();
                var queryable = contextEvents
                    .Select(Mapper.Map<Models.ApiModels.Event>);
                var events = queryable
                    .ToArray();

                return events;
            }
        }
    }
}