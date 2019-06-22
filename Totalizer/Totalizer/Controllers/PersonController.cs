using BusinessLogickLayer.Interfaces;
using Models;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class PersonController : ApiController
    {
        IPersonService connector;

        public PersonController(IPersonService _connector)
        {
            connector = _connector;
        }

        [Route("person")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        public string GetCountriesList()
        {
            string countriesString = JsonConvert.SerializeObject(connector.GetItemsList());
            return countriesString;
        }

        public Person GetPersonById(int id)
        {
            return connector.GetItemById(id);
        }

        public void CreatePerson(Person person)
        {
            connector.CreateItem(person);
        }

        public void UpdatePerson(Person person)
        {
            connector.UpdateItem(person);
        }

        public void DeletePerson(int id)
        {
            connector.DeleteItem(id);
        }
    }
}
