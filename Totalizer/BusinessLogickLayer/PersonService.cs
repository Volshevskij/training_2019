using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class PersonService : IPersonService
    {
        IRepository<Person> repository;

        public PersonService(IRepository<Person> _repository)
        {
            repository = _repository;
        }

        public void CreateItem(Person person)
        {
            repository.CreateItem(person);
        }

        public void UpdateItem(Person person)
        {
            repository.UpdateItem(person);
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public IEnumerable<Person> GetItemsList()
        {
            return repository.GetItemsList();
        }

        public Person GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
