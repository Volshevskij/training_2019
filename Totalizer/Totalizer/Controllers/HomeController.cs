using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogickLayer;
using System.Web.Http.Cors;

namespace Totalizer.Controllers
{
    public class HomeController : Controller
    {
        LogickConnector logickConnector;

        public HomeController(LogickConnector _logickConnector)
        {
            logickConnector = _logickConnector;
        }

        //Delete this
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        public List<Bet> GetAllBets()
        {
            return logickConnector.GetBets();
        }

        [HttpGet]
        public List<Event> GetAllEvents()
        {
            return logickConnector.GetEvents();
        }
    }
}
