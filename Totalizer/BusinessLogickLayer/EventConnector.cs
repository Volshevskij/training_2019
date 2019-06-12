using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class EventConnector:ILogickRepository<Event>
    {
        IRepository<Event> sqlDataAccess;

        public EventConnector(IRepository<Event> _sqlDataAccess)
        {
            sqlDataAccess = _sqlDataAccess;
        }

        public void CreateItem(Event @event)
        {
            sqlDataAccess.CreateItem(@event);
        }

        public void UpdateItem(Event @event)
        {
            sqlDataAccess.UpdateItem(@event);
        }

        public void DeleteItem(int id)
        {
            sqlDataAccess.DeleteItem(id);
        }

        public IEnumerable<Event> GetItemsList()
        {
            return sqlDataAccess.GetItemsList();
        }

        public Event GetItemById(int id)
        {
            return sqlDataAccess.GetItemById(id);
        }
    }
}
