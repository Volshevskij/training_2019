using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class SportTypeController : ApiController
    {
        ISportTypeService service;

        public SportTypeController(ISportTypeService _service)
        {
            service = _service;
        }

        [Route("sport_type")]
        [HttpGet]
        public IEnumerable<SportType> GetSportTypeList()
        {         
            return service.GetItemsList();
        }

        [Route("sport_type/{id}")]
        [HttpGet]
        public SportType GetSportTypeById(int id)
        {
            return service.GetItemById(id);
        }

        [Authorize(Roles = "Editor")]
        [Route("sport_type")]
        [HttpPost]
        public IHttpActionResult CreateSportType(SportType sportType)
        {
            service.CreateItem(sportType);
            return Created("sportType", sportType);
        }

        [Authorize(Roles = "Editor")]
        [Route("sport_type")]
        [HttpPatch]
        public IHttpActionResult UpdateSportType(SportType sportType)
        {
            service.UpdateItem(sportType);
            return Ok();
        }

        [Authorize(Roles = "Editor")]
        [Route("sport_type/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteSportType(int id)
        {
            service.DeleteItem(id);
            return Ok();
        }

        [Route("sport_type")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }
    }
}
