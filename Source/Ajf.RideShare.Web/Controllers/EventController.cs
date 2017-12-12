using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ajf.RideShare.Web.Models;
using Newtonsoft.Json;
using TripGallery.MVCClient.Helpers;

namespace Ajf.RideShare.Web.Controllers
{
    public class EventController : Controller
    {

        [Authorize]
        public ActionResult Create()
        {
            return View(new EventCreateViewModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(EventCreateViewModel eventCreateViewModel)
        {
            try
            {

                //byte[] uploadedImage = new byte[vm.PictureFile.InputStream.Length];
                //vm.PictureFile.InputStream.Read(uploadedImage, 0, uploadedImage.Length);

                //vm.Picture.PictureBytes = uploadedImage;

                //var httpClient = RideShareHttpClient.GetClient();

                //var serializedTrip = JsonConvert.SerializeObject(vm.Picture);

                //var response = await httpClient.PostAsync("api/trips/" + vm.TripId.ToString() + "/pictures",
                //    new StringContent(serializedTrip, System.Text.Encoding.Unicode, "application/json")).ConfigureAwait(false);

                //if (response.IsSuccessStatusCode)
                //{
                //    return RedirectToAction("Index", "Pictures", new { tripId = vm.TripId });
                //}
                //else
                //{
                //    return View("Error",
                //        new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(response),
                //            "Pictures", "Create"));
                //}
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Event", "Create"));
            }
        }
    }
}