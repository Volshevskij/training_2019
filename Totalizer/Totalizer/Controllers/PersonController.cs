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

        [Authorize(Roles = "Admin")]
        [Route("person")]
        [HttpPost]
        public IHttpActionResult CreatePerson(Person person)
        {
            service.CreateItem(person);
            return Created("person", person);
        }

        [Authorize(Roles = "User")]
        [Route("person")]
        [HttpPatch]
        public IHttpActionResult UpdatePerson(Person person)
        {
            service.UpdateItem(person);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("person/{id}")]
        [HttpDelete]
        public IHttpActionResult DeletePerson(int id)
        {
            service.DeleteItem(id);
            return Ok();
        }

        [Route("person")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }
    }
}
