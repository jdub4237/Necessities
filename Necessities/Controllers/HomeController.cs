using System.Web.Mvc;

namespace Necessities.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to NecessitiesThriftShop.com!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "25 years in business.  Gently used clothing, and many more one of a kind items.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Located near the corner of 7 highway and Walnut in Blue Springs, MO.  We are in a large salmon colored house with convenient drive around parking.";

            return View();
        }
    }
}
