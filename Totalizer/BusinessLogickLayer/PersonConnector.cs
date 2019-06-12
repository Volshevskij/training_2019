using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class PersonConnector : ILogickRepository<Person>
    {
        IRepository<Person> sqlDataAccess;

        public PersonConnector(IRepository<Person> _sqlDataAccess)
        {
            sqlDataAccess = _sqlDataAccess;
        }

        public void CreateItem(Person person)
        {
            sqlDataAccess.CreateItem(person);
        }

        public void UpdateItem(Person person)
        {
            sqlDataAccess.UpdateItem(person);
        }

        public void DeleteItem(int id)
        {
            sqlDataAccess.DeleteItem(id);
        }

        public IEnumerable<Person> GetItemsList()
        {
            return sqlDataAccess.GetItemsList();
        }

        public Person GetItemById(int id)
        {
            return sqlDataAccess.GetItemById(id);
        }
    }
}
