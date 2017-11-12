using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using Ajf.RideShare.Models;
using Ajf.RideShare.Web.Models.ViewModels.Home;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNet.Identity;

namespace Ajf.RideShare.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                ViewBag.Title = "Hovedside";

                //var applicationUser = context.Users.Single(x=>x.UserName==User.Identity.Name);
                var userName = User.Identity.GetUserName();
                var events = context.Events.Where(x =>x.OwnerUserId == userName);
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