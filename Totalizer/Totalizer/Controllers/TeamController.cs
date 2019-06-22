using BusinessLogickLayer.Interfaces;
using Models;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class TeamController : ApiController
    {
        ITeamService connector;

        public TeamController(ITeamService _connector)
        {
            connector = _connector;
        }

        [Route("team")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        public string GetTeamsList()
        {
            string countriesString = JsonConvert.SerializeObject(connector.GetItemsList());
            return countriesString;
        }

        public Team GetTeamById(int id)
        {
            return connector.GetItemById(id);
        }

        public void CreateTeam(Team team)
        {
            connector.CreateItem(team);
        }

        public void UpdateTeam(Team team)
        {
            connector.UpdateItem(team);
        }

        public void DeleteTeam(int id)
        {
            connector.DeleteItem(id);
        }
    }
}
