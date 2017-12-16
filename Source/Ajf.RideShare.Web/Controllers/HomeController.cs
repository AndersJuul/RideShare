using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ajf.RideShare.Models;
using Ajf.RideShare.Web.Helpers;
using Ajf.RideShare.Web.Models;
using AutoMapper;
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

                var rspTrips = await httpClient.GetAsync("Api/Events/").ConfigureAwait(false);

                if (rspTrips.IsSuccessStatusCode)
                {
                    var lstTripsAsString = await rspTrips.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var models= JsonConvert.DeserializeObject<IList<Event>>(lstTripsAsString).ToList();
                    var eventViewModels = models.Select(x=> Mapper.Map<EventViewModel>(x));

                    var vm = new HomeIndexViewModel();
                    vm.Events.AddRange(eventViewModels);

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