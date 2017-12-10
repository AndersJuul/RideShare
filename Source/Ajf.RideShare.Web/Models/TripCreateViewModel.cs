using System.Web;
using TripGallery.DTO;

namespace Ajf.RideShare.Web.Models
{
    public class TripCreateViewModel
    {
         
        public HttpPostedFileBase MainImage { get; set; }

        public TripForCreation Trip { get; set; }

        public TripCreateViewModel()
        {

        }

        public TripCreateViewModel(TripForCreation trip)
        {
            Trip = trip;
        }
    }
}
