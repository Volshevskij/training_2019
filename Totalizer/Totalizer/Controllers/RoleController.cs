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
        public void CreateRole(Role role)
        {
            service.CreateItem(role);
        }

        [Authorize(Roles = "Editor")]
        [Route("role")]
        [HttpPatch]
        public void UpdateRole([FromBody]Role role)
        {
            service.UpdateItem(role);
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
        public void DeleteRole(int id)
        {
            service.DeleteItem(id);
        }
    }
}
