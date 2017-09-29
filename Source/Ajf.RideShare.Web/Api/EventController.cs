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
                return context
                    .Events
                    .Select(x=>Mapper.Map<Web.Models.ApiModels.Event>(x))
                    .ToArray();
            }
        }
    }
}