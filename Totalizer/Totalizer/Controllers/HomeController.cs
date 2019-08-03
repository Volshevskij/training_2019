using BusinessLogickLayer.Interfaces;
using Models;
using System.Web.Mvc;

namespace Totalizer.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
