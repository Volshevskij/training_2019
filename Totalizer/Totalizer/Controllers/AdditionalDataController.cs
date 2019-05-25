using BusinessLogickLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Totalizer.Controllers
{
    public class AdditionalDataController : Controller
    {
        LogickConnector logickConnector;

        public AdditionalDataController(LogickConnector _logickConnector)
        {
            logickConnector = _logickConnector;
        }

        public ActionResult Index()
        {
            return View();
        }

        public List<Country> GetAllCountries()
        {
            return logickConnector.GetCountries();
        }

        public List<SportType> GetAllSportTypes()
        {
            return logickConnector.GetSportTypes();
        }

        public List<Team> GetAllTeams()
        {
            return logickConnector.GetTeams();
        }

        public List<Person> GetAllPersons()
        {
           return logickConnector.GetPersons();
        }

        public List<Event> GetAllEvents()
        {
            return logickConnector.GetEvents();
        }

        public List<Bet> GetAllBets()
        {
            return logickConnector.GetBets();
        }
    }
}