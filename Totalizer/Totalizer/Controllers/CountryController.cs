using BusinessLogickLayer.Interfaces;
using Models;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class CountryController : ApiController
    {
        ICountryService connector;

        public CountryController(ICountryService _connector)
        {
            connector = _connector;
        }

        [Route("country")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        public string GetCountriesList()
        {
            string countriesString = JsonConvert.SerializeObject(connector.GetItemsList());
            return countriesString;
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