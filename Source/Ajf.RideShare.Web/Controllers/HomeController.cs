using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ajf.RideShare.Web.Helpers;
using Ajf.RideShare.Web.Models;
using Newtonsoft.Json;
using TripGallery.DTO;
using TripGallery.MVCClient.Helpers;

namespace Ajf.RideShare.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var httpClient = RideShareHttpClient.GetClient();
                var sub = ((ClaimsIdentity)User.Identity).Claims.Single(x=>x.Type=="sub").Value;
                var rspTrips = await httpClient.GetAsync("Api/Events/"+sub).ConfigureAwait(false);

                if (rspTrips.IsSuccessStatusCode)
                {
                    var lstTripsAsString = await rspTrips.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var vm = new TripsIndexViewModel();
                    var sList= JsonConvert.DeserializeObject<IList<string>>(lstTripsAsString).ToList();

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