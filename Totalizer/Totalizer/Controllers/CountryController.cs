using BusinessLogickLayer.Interfaces;
using Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class CountryController : ApiController
    {
        ILogickRepository<Country> connector;

        public CountryController(ILogickRepository<Country> _connector)
        {
            connector = _connector;
        }

        [Route("country")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        public string GetCountriesList()
        {
            // используйте newtowsoft
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string outputOfInts = serializer.Serialize(connector.GetItemsList());
            return outputOfInts;
        }

        public Country GetCountryById(int id)
        {
           return connector.GetItemById(id);
        }

        public void CreateCountry(Country country)
        {
            connector.CreateItem(country);
        }

        public void UpdateCountry(Country country)
        {
            connector.UpdateItem(country);
        }

        public void DeleteCountry(int id)
        {
            connector.DeleteItem(id);
        }
    }
}