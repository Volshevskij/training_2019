using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class PersonService : IPersonService
    {
        IRepository<Person> sqlDataAccess;

        public PersonService(IRepository<Person> _sqlDataAccess)
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
