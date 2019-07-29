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
        public void CreateEvent(Event @event)
        {
            service.CreateItem(@event);
        }

        [Authorize(Roles = "Editor")]
        [Route("event")]
        [HttpPatch]
        public void UpdateEvent(Event @event)
        {
            service.UpdateItem(@event);
        }

        [Authorize(Roles = "Editor")]
        [Route("event/{id}")]
        [HttpDelete]
        public void DeleteEvent(int id)
        {
            service.DeleteItem(id);
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