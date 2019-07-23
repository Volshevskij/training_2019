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

        [Route("sport_type")]
        [HttpPost]
        public void CreateSportType(SportType sportType)
        {
            service.CreateItem(sportType);
        }

        [Route("sport_type")]
        [HttpPatch]
        public void UpdateSportType(SportType sportType)
        {
            service.UpdateItem(sportType);
        }

        [Route("sport_type/{id}")]
        [HttpDelete]
        public void DeleteSportType(int id)
        {
            service.DeleteItem(id);
        }

        [Route("sport_type")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }
    }
}
