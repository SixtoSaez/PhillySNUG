using System.Web.Mvc;
using RealWorld.Application;
using RealWorld.Models;

namespace RealWorld.Controllers
{
    /// <summary>
    /// The HTML based home page (resource)
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignedIn(Credentials credentials)
        {
            //TODO: please use a real and secure authentication scheme!!
            credentials.Password = null;

            var authCookie = Cookies.CreateAuthCookie();
            HttpContext.Response.AppendCookie(authCookie);

            return View(credentials);
        }

        public ActionResult Error(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }
    }
}
