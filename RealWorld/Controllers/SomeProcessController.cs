using System.Web.Mvc;
using RealWorld.Application;
using RealWorld.Models;

namespace RealWorld.Controllers
{
    [WebAuthorize]
    public class SomeProcessController : Controller
    {
        //
        // GET: /SomeProcess/

        public ActionResult Index()
        {
            var processStatus = new BizProcessStatus {Status = "All is good"};
            return View(processStatus);
        }

    }
}
