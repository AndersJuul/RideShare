using System.Collections.ObjectModel;
using System.Web.Mvc;

namespace Ajf.RideShare.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeIndexViewModel = new HomeIndexViewModel
            {
                Events = new Collection<EventViewModel>
                {
                    new EventViewModel {Description = "Abc"},
                    new EventViewModel {Description = "Def"}
                }
            };
            return View(homeIndexViewModel);
        }
    }
}