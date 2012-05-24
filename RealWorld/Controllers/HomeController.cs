using System;
using System.Web;
using System.Web.Mvc;
using RealWorld.Models;

namespace RealWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(Credentials credentials)
        {
            //TODO: please use a real and secure authentication scheme!!
            credentials.Password = null;

            var authCookie = new HttpCookie("AppAuthentication");
            authCookie.Expires = DateTime.Now.AddSeconds(30);
            authCookie.Value = "someSuperCoolEncryptedValue";
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
