using System.Collections.Generic;

namespace Ajf.RideShare.Web.Models.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public ICollection<EventViewModel> Events { get; set; }
    }
}