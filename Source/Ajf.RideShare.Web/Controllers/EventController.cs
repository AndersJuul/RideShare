using System.Web.Mvc;

namespace Ajf.RideShare.Web.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Create()
        {
            return View();
        }
    }
}