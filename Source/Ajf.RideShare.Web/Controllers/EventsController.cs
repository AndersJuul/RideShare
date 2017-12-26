using System;
using System.Net.Http;
using System.Text;
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
    public class EventsController : RideShareController
    {
        [Authorize]
        public ActionResult Create()
        {
            var eventCreateViewModel = new EventViewModel
            {
                EventId = Guid.NewGuid(),
                Date = DateTime.Now,
                ViewModelMode = ViewModelMode.Create
            };
            return View("Details", eventCreateViewModel);
        }

        [Authorize]
        [Route("api/Events/Edit/{eventId}")]
        public async Task<ActionResult> Edit(Guid eventId)
        {
            return await
                DetailsViewOfEvent(eventId, ViewModelMode.Edit)
                    .ConfigureAwait(false);
        }

        private async Task<ActionResult> DetailsViewOfEvent(Guid eventId, ViewModelMode viewModelMode)
        {
            try
            {
                var httpClient = RideShareHttpClient.GetClient();

                var response = await httpClient.GetAsync("api/events/" + eventId)
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var @event = JsonConvert.DeserializeObject<Event>(responseString);

                    var eventViewModel = Mapper.Map<Event, EventViewModel>(@event);
                    eventViewModel.ViewModelMode = viewModelMode;

                    return View("Details", eventViewModel);
                }
                
                var exceptionFromResponse = ExceptionHelper.GetExceptionFromResponse(response);

                Log.Logger.Error(exceptionFromResponse, "Call to API was not successful.");

                return View("Error",
                    new HandleErrorInfo(exceptionFromResponse,
                        "Events", "Create"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "During DetailsOfEvent");
                return View("Error", new HandleErrorInfo(ex, "Events", "Create"));
            }
        }

        [Authorize]
        [Route("api/Events/Details/{eventId}")]
        public async Task<ActionResult> Details(Guid eventId)
        {
            return await
                DetailsViewOfEvent(eventId, ViewModelMode.View)
                    .ConfigureAwait(false);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Edit(EventViewModel eventViewModel)
        {
            try
            {
                throw new Exception("Dummy!");
                var httpClient = RideShareHttpClient.GetClient();

                var serializedTrip = JsonConvert.SerializeObject(eventViewModel);

                var response = await httpClient.PutAsync("api/events/" + eventViewModel.EventId,
                        new StringContent(serializedTrip, Encoding.Unicode, "application/json"))
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Home");
                return View("Error",
                    new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(response),
                        "Events", "Edit"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex,"During post to Edit");
                return View("Error", new HandleErrorInfo(ex, "Events", "Edit"));
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(EventViewModel eventCreateViewModel)
        {
            try
            {
                var httpClient = RideShareHttpClient.GetClient();

                var serializedTrip = JsonConvert.SerializeObject(eventCreateViewModel);

                var response = await httpClient.PostAsync("api/events/",
                        new StringContent(serializedTrip, Encoding.Unicode, "application/json"))
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Home");
                return View("Error",
                    new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(response),
                        "Events", "Create"));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Events", "Create"));
            }
        }
    }
}