using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ajf.RideShare.Web.Helpers;
using Ajf.RideShare.Web.Models;
using Newtonsoft.Json;
using TripGallery.MVCClient.Helpers;

namespace Ajf.RideShare.Web.Controllers
{
    public class EventsController : Controller
    {

        [Authorize]
        public ActionResult Create()
        {
            var eventCreateViewModel = new EventCreateViewModel()
            {
                EventId = Guid.NewGuid(),
                Date = DateTime.Now
            };
            return View(eventCreateViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(EventCreateViewModel eventCreateViewModel)
        {
            try
            {
                var httpClient = RideShareHttpClient.GetClient();

                var serializedTrip = JsonConvert.SerializeObject(eventCreateViewModel);

                var response = await httpClient.PostAsync("api/events/",
                    new StringContent(serializedTrip, System.Text.Encoding.Unicode, "application/json"))
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("Edit", "Events", new { eventId = eventCreateViewModel.EventId });
                }
                else
                {
                    return View("Error",
                        new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(response),
                            "Pictures", "Create"));
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Events", "Create"));
            }
        }
    }
}