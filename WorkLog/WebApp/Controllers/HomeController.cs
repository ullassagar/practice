using System.Web.Mvc;
using Indpro.Attendance.WebApp;

namespace Indpro.Attendance.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "WebApp";
            return View();
        }
    }
}