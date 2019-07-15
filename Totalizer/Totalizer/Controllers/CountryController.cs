using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class CountryController : ApiController
    {
        ICountryService service;

        public CountryController(ICountryService _service)
        {
            service = _service;
        }

        [Route("country")]
        [HttpGet]
        public IEnumerable<Country> GetCountriesList()
        {
            return service.GetItemsList();
        }

        [Route("country/{id}")]
        [HttpGet]
        public Country GetCountryById(int id)
        {
           return service.GetItemById(id);
        }

        [Route("country")]
        [HttpPost]
        public void CreateCountry(Country country)
        {
            service.CreateItem(country);
        }

        [Route("country")]
        [HttpPatch]
        public void UpdateCountry([FromBody]Country country)
        {
            service.UpdateItem(country);
        }

        [Route("country")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }

        [Route("country/{id}")]
        [HttpDelete]
        public void DeleteCountry(int id)
        {
            service.DeleteItem(id);
        }
    }
}