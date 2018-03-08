using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Index(int? code)
        {
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult ErrorCustom()
        {
            return View();
        }

    }
}