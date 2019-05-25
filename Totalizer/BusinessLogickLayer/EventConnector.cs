using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogickLayer
{
    class EventConnector
    {
        SqlServerEventModelAccess sqlDataAccess = new SqlServerEventModelAccess();

        public void AddEvent(Event @event)
        {
            sqlDataAccess.CreateItem(@event);
        }

        public void UpdateEvent(Event @event)
        {
            sqlDataAccess.UpdateItem(@event);
        }

        public void DeleteEvent(Event @event)
        {
            sqlDataAccess.DeleteItem(@event);
        }

        public IEnumerable<Event> GetEvents()
        {
            return sqlDataAccess.GetItemsList();
        }

        public Event GetEventByID(int id)
        {
            return sqlDataAccess.GetItemByID(id);
        }
    }
}
