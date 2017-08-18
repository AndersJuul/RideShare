using System.Collections.ObjectModel;
using System.Web.Mvc;
using Ajf.RideShare.Web.Models;
using Ajf.RideShare.Web.Models.Home;

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