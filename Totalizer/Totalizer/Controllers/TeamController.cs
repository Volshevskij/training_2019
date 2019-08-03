using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class TeamController : ApiController
    {
        ITeamService service;

        public TeamController(ITeamService _service)
        {
            service = _service;
        }

        [Route("team")]
        [HttpGet]
        public IEnumerable<Team> GetTeamsList()
        {
            return service.GetItemsList();
        }

        [Route("team/{id}")]
        [HttpGet]
        public Team GetTeamById(int id)
        {
            return service.GetItemById(id);
        }

        [Authorize(Roles = "Editor")]
        [Route("team")]
        [HttpPost]
        public IHttpActionResult CreateTeam(Team team)
        {
            service.CreateItem(team);
            return Created("team", team);
        }

        [Authorize(Roles = "Editor")]
        [Route("team")]
        [HttpPatch]
        public IHttpActionResult UpdateTeam(Team team)
        {
            service.UpdateItem(team);
            return Ok();
        }

        [Authorize(Roles = "Editor")]
        [Route("team/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTeam(int id)
        {
            service.DeleteItem(id);
            return Ok();
        }

        [Route("team")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }
    }
}
