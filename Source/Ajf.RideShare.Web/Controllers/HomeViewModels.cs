using System.Collections;
using System.Collections.Generic;

namespace Ajf.RideShare.Web.Controllers
{
    public class HomeIndexViewModel
    {
        public ICollection<EventViewModel> Events { get; set; }
    }

    public class EventViewModel
    {
        public string Description { get; set; }
    }
}