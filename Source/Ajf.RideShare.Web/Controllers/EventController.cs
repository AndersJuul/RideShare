using System.Linq;
using System.Web.Mvc;
using Ajf.RideShare.Models;
using Ajf.RideShare.Web.Models.Home;
using AutoMapper;

namespace Ajf.RideShare.Web.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        public ActionResult Get(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var event1 = context.Events.Single(x => x.Id == id);

                var eventDetailsViewModel = Mapper.Map<EventDetailsViewModel>(event1);
                return View("EventDetails", eventDetailsViewModel);
            }
        }

        public ActionResult AddCar()
        {
            return View();
        }

        public ActionResult AddPassenger()
        {
            return View();
        }
    }
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