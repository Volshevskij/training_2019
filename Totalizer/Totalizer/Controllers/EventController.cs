using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class EventController : ApiController
    {
        IEventService service;

        public EventController(IEventService _service)
        {
            service = _service;
        }

        [Authorize(Roles = "Editor")]
        [Route("event")]
        [HttpPost]
        public IHttpActionResult CreateEvent(Event @event)
        {
            service.CreateItem(@event);
            return Created("event", @event);
        }

        [Authorize(Roles = "Editor")]
        [Route("event")]
        [HttpPatch]
        public IHttpActionResult UpdateEvent(Event @event)
        {
            service.UpdateItem(@event);
            return Ok();
        }

        [Authorize(Roles = "Editor")]
        [Route("event/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteEvent(int id)
        {
            service.DeleteItem(id);
            return Ok();
        }

        [Route("event")]
        [HttpGet]
        public IEnumerable<Event> GetEventsList()
        {
            return service.GetItemsList();
        }

        [Route("event/{id}")]
        [HttpGet]
        public Event GetEventByID(int id)
        {
            return service.GetItemById(id);
        }

        [Route("event")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }
    }
}