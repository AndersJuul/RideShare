using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using Ajf.RideShare.Models;
using Ajf.RideShare.Web.Models.Home;
using AutoMapper;

namespace Ajf.RideShare.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var events = context.Events; //.Where(x => x.OwnerUserId == "");
                var eventViewModels = events.Select(Mapper.Map<EventViewModel>).ToArray();

                var homeIndexViewModel = new HomeIndexViewModel
                {
                    Events = new Collection<EventViewModel>(eventViewModels)
                };
                return View(homeIndexViewModel);
            }
        }
    }
}