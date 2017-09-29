using System.Web;
using System.Web.Http;
using Ajf.RideShare.Web.Models;
using Ajf.RideShare.Web.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Ajf.RideShare.Web.Api
{
    [Authorize]
    public class MeController : ApiController
    {
        private ApplicationUserManager _userManager;

        public MeController()
        {
        }

        public MeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/Me
        public GetViewModel Get()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return new GetViewModel();
        }
    }
}