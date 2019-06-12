using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Totalizer.Controllers
{
    public class EventController : Controller
    {
        ILogickRepository<Event> connector;

        public EventController(ILogickRepository<Event> _connector)
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

        public IEnumerable<Event> GetEventsList()
        {
            return connector.GetItemsList();
        }

        public Event GetEventByID(int id)
        {
            return connector.GetItemById(id);
        }
    }
}