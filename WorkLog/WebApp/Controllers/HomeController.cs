using System.Web.Mvc;
using Indpro.Attendance.WebApp.Utilities;

namespace Indpro.Attendance.WebApp.Controllers
{
    [AuthorizeMember]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "WebApp";
            return View();
        }
    }
}