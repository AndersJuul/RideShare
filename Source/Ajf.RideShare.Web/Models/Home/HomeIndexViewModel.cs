using System.Collections.Generic;

namespace Ajf.RideShare.Web.Models.Home
{
    public class HomeIndexViewModel
    {
        public ICollection<EventViewModel> Events { get; set; }
    }
}