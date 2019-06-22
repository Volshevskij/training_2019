using BusinessLogickLayer.Interfaces;
using Models;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class SportTypeController : ApiController
    {
        ISportTypeService connector;

        public SportTypeController(ISportTypeService _connector)
        {
            connector = _connector;
        }

        [Route("sport_type")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        public string GetSportTypeList()
        {
            string countriesString = JsonConvert.SerializeObject(connector.GetItemsList());
            return countriesString;
        }

        public SportType GetSportTypeById(int id)
        {
            return connector.GetItemById(id);
        }

        public void CreateSportType(SportType sportType)
        {
            connector.CreateItem(sportType);
        }

        public void UpdateSportType(SportType sportType)
        {
            connector.UpdateItem(sportType);
        }

        public void DeleteSportType(int id)
        {
            connector.DeleteItem(id);
        }
    }
}
