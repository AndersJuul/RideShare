using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ajf.RideShare.Models;
using Ajf.RideShare.Web.Helpers;
using Ajf.RideShare.Web.Models;
using AutoMapper;
using Newtonsoft.Json;
using TripGallery.MVCClient.Helpers;

namespace Ajf.RideShare.Web.Controllers
{
    public class EventsController : RideShareController
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

        //[Route("api/Events/Edit/{eventId}")]
        //public async Task<IHttpActionResult> Edit(Guid eventId)
        //{
        //    return View(new EditEventViewModel());
        //}
        //public class EditEventViewModel
        //{
        //    public Guid EventId { get; set; }
        //    public DateTime Date { get; set; }
        //    public string Description { get; set; }
        //}
        [Authorize]
        [Route("api/Events/Edit/{eventId}")]
        public async Task<ActionResult> Edit(Guid eventId)
        {
            try
            {
                var httpClient = RideShareHttpClient.GetClient();
                
                var response = await httpClient.GetAsync("api/events/"+eventId)
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var @event = JsonConvert.DeserializeObject<Event>(responseString);

                    var eventViewModel = Mapper.Map<Event,EventViewModel>(@event);

                    return View(eventViewModel);
                }
                else
                {
                    return View("Error",
                        new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(response),
                            "Events", "Create"));
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Events", "Create"));
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Edit(EventViewModel eventViewModel)
        {
            try
            {
                var httpClient = RideShareHttpClient.GetClient();

                var serializedTrip = JsonConvert.SerializeObject(eventViewModel);

                var response = await httpClient.PutAsync("api/events/"+eventViewModel.EventId,
                        new StringContent(serializedTrip, System.Text.Encoding.Unicode, "application/json"))
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Error",
                        new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(response),
                            "Events", "Edit"));
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Events", "Edit"));
            }
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
                }
                else
                {
                    return View("Error",
                        new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(response),
                            "Events", "Create"));
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Events", "Create"));
            }
        }
    }
}