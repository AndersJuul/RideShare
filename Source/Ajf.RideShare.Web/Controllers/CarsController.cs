using System.Web.Mvc;

namespace Ajf.RideShare.Web.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        public ActionResult Add()
        {
            return RedirectToAction("Index", "Home");
            //using (var context = new ApplicationDbContext())
            //{
            //    var event1 = context.Events.Single(x => x.Id == id);

            //    var eventDetailsViewModel = Mapper.Map<EventDetailsViewModel>(event1);
            //    return View("EventDetails", eventDetailsViewModel);
            //}
        }
    }
}