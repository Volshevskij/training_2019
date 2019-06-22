using BusinessLogickLayer.Interfaces;
using Models;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class EventController : ApiController
    {
        IEventService connector;

        public EventController(IEventService _connector)
        {
            connector = _connector;
        }

        public void CreateEvent(Event @event)
        {
            connector.CreateItem(@event);
        }

        public void UpdateEvent(Event @event)
        {
            connector.UpdateItem(@event);
        }

        public void DeleteEvent(int id)
        {
            connector.DeleteItem(id);
        }

        [Route("event")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        public string GetEventsList()
        {
            string countriesString = JsonConvert.SerializeObject(connector.GetItemsList());
            return countriesString;
        }

        public Event GetEventByID(int id)
        {
            return connector.GetItemById(id);
        }
    }
}