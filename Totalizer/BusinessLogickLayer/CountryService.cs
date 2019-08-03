using BusinessLogickLayer.Cacher;
using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class CountryService : ICountryService
    {
        ICountryRepository repository;
        IMemoryCacher memoryCacher;

        public CountryService(ICountryRepository _repository, IMemoryCacher _memoryCacher)
        {
            repository = _repository;
            memoryCacher = _memoryCacher;
        }

        public void CreateItem(Country country)
        {
            memoryCacher.Delete("country");
            repository.CreateItem(country);
        }

        public void UpdateItem(Country country)
        {
            memoryCacher.Delete("country");
            repository.UpdateItem(country);
        }

        public void DeleteItem(int id)
        {
            memoryCacher.Delete("country");
            repository.DeleteItem(id);
        }

        public IEnumerable<Country> GetItemsList()
        {
            return memoryCacher.CheckCache("country", repository.GetItemsList(), DateTimeOffset.UtcNow.AddHours(1)) as IEnumerable<Country>;
        }

        public Country GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
