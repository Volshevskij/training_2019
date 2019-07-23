using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class PersonController : ApiController
    {
        IPersonService service;

        public PersonController(IPersonService _service)
        {
            service = _service;
        }

        [Route("person")]
        [HttpGet]
        public IEnumerable<Person> GetPersonsList()
        {
            return service.GetItemsList();
        }

        [Route("person/{id}")]
        [HttpGet]
        public Person GetPersonById(int id)
        {
            return service.GetItemById(id);
        }

        [Route("person")]
        [HttpPost]
        public void CreatePerson(Person person)
        {
            service.CreateItem(person);
        }

        [Route("person")]
        [HttpPatch]
        public void UpdatePerson(Person person)
        {
            service.UpdateItem(person);
        }

        [Route("person/{id}")]
        [HttpDelete]
        public void DeletePerson(int id)
        {
            service.DeleteItem(id);
        }

        [Route("person")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }
    }
}
