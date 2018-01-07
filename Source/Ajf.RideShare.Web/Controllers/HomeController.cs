using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ajf.RideShare.Models;
using Ajf.RideShare.Web.Helpers;
using Ajf.RideShare.Web.Models;
using AutoMapper;
using Newtonsoft.Json;
using Serilog;

namespace Ajf.RideShare.Web.Controllers
{
    public class HomeController : RideShareController
    {
        [Authorize]
        public ActionResult RedirectToIndex()
        {
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                Log.Logger.Debug("Trace: User is authenticated." );
                var httpClient = RideShareHttpClient.GetClient();

                Log.Logger.Debug("HttpClient base url :" +httpClient.BaseAddress.AbsolutePath);

                var activeEvents = await httpClient
                    .GetAsync("Api/Events/")
                    .ConfigureAwait(false);

                var activeEventsAsString = await activeEvents
                    .Content.ReadAsStringAsync()
                    .ConfigureAwait(false);

                if (activeEvents.IsSuccessStatusCode)
                {
                    var models= JsonConvert.DeserializeObject<IList<Event>>(activeEventsAsString).ToList();
                    var eventViewModels = models.Select(Mapper.Map<EventViewModel>);

                    var vm = new HomeIndexViewModel();
                    vm.Events.AddRange(eventViewModels);

                    return View(vm);
                }

                Log.Logger.Error($"Non-successful call to API: {@activeEvents.StatusCode}, {activeEventsAsString}");

                return View("Error",
                    new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(activeEvents),
                        "Home", "Index"));
            }
            return View();
        }
    }
}