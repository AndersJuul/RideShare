using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using TripGallery.DTO;
using TripGallery.MVCClient.Helpers;
using TripGallery.MVCClient.Models;

namespace Ajf.RideShare.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var httpClient = TripGalleryHttpClient.GetClient();
                var rspTrips = await httpClient.GetAsync("Api/Events").ConfigureAwait(false);

                if (rspTrips.IsSuccessStatusCode)
                {
                    var lstTripsAsString = await rspTrips.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var vm = new TripsIndexViewModel();
                    vm.Trips = JsonConvert.DeserializeObject<IList<Trip>>(lstTripsAsString).ToList();

                    return View(vm);
                }
                return View("Error",
                    new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(rspTrips),
                        "Home", "Index"));
            }
            return View();
        }
    }
}