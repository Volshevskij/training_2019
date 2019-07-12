using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class SportTypeService : ISportTypeService
    {
        IRepository<SportType> repository;

        public SportTypeService(IRepository<SportType> _repository)
        {
            repository = _repository;
        }

        public void CreateItem(SportType sportType)
        {
            repository.CreateItem(sportType);
        }

        public void UpdateItem(SportType sportType)
        {
            repository.UpdateItem(sportType);
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public IEnumerable<SportType> GetItemsList()
        {
            return repository.GetItemsList();
        }

        public SportType GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
