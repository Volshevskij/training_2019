using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class RoleController : ApiController
    {
        IRoleService service;

        public RoleController(IRoleService _service)
        {
            service = _service;
        }

        [Route("role")]
        [HttpGet]
        public IEnumerable<Role> GetRolesList()
        {
            return service.GetItemsList();
        }

        [Route("role/{id}")]
        [HttpGet]
        public Role GetRoleById(int id)
        {
            return service.GetItemById(id);
        }

        [Authorize(Roles = "Editor")]
        [Route("role")]
        [HttpPost]
        public IHttpActionResult CreateRole(Role role)
        {
            service.CreateItem(role);
            return Created("role", role);
        }

        [Authorize(Roles = "Editor")]
        [Route("role")]
        [HttpPatch]
        public IHttpActionResult UpdateRole([FromBody]Role role)
        {
            service.UpdateItem(role);
            return Ok();
        }

        [Route("role")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }

        [Authorize(Roles = "Editor")]
        [Route("role/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteRole(int id)
        {
            service.DeleteItem(id);
            return Ok();
        }
    }
}
