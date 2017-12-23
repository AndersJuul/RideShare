using System.Web;
using System.Web.Mvc;

namespace Ajf.RideShare.Web.Controllers
{
    public class UserAccountController : RideShareController
    {
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }

        public ActionResult LocalLogout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}