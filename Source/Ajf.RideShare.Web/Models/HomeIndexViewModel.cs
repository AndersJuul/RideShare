using System.Collections.Generic;

namespace Ajf.RideShare.Web.Models
{
    public class HomeIndexViewModel
    {
        public List<EventViewModel> Events { get; set; }
 


        public HomeIndexViewModel()
        {
            Events = new List<EventViewModel>();
        }
    }
}
