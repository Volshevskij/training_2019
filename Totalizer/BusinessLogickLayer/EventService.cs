using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class EventService:IEventService
    {
        IRepository<Event> repository;

        public EventService(IRepository<Event> _repository)
        {
            repository = _repository;
        }

        public void CreateItem(Event @event)
        {
            repository.CreateItem(@event);
        }

        public void UpdateItem(Event @event)
        {
            repository.UpdateItem(@event);
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public IEnumerable<Event> GetItemsList()
        {
            return repository.GetItemsList();
        }

        public Event GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
