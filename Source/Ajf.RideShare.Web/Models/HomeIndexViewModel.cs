using System.Collections.Generic;
using TripGallery.DTO;

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
