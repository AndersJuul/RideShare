using System.Collections.Generic;
using TripGallery.DTO;

namespace Ajf.RideShare.Web.Models
{
    public class TripsIndexViewModel
    {
        public List<Trip> Trips { get; set; }
 


        public TripsIndexViewModel()
        {
            Trips = new List<Trip>();
        }
    }
}
