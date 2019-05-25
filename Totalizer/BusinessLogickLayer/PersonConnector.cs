using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogickLayer
{
    class PersonConnector
    {
        SqlServerPersonModelAccess sqlDataAccess = new SqlServerPersonModelAccess();

        public void AddPerson(Person person)
        {
            sqlDataAccess.CreateItem(person);
        }

        public void UpdatePerson(Person person)
        {
            sqlDataAccess.UpdateItem(person);
        }

        public void DeletePerson(Person person)
        {
            sqlDataAccess.DeleteItem(person);
        }

        public IEnumerable<Person> GetPersons()
        {
            return sqlDataAccess.GetItemsList();
        }

        public Person GetPersonByID(int id)
        {
            return sqlDataAccess.GetItemByID(id);
        }
    }
}
