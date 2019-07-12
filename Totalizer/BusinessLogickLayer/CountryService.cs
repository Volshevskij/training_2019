using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class CountryService:ICountryService
    {
        IRepository<Country> repository;

        public CountryService(IRepository<Country> _repository)
        {
            repository = _repository;
        }

        public void CreateItem(Country country)
        {
            repository.CreateItem(country);
        }

        public void UpdateItem(Country country)
        {
            repository.UpdateItem(country);
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public IEnumerable<Country> GetItemsList()
        {
            return repository.GetItemsList();
        }

        public Country GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
