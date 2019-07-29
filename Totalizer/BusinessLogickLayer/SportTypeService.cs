using BusinessLogickLayer.Cacher;
using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class SportTypeService : ISportTypeService
    {
        ISportTypeRepository repository;
        IMemoryCacher memoryCacher;

        public SportTypeService(ISportTypeRepository _repository, IMemoryCacher _memoryCacher)
        {
            repository = _repository;
            memoryCacher = _memoryCacher;
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
            return memoryCacher.CheckCache("sportType", repository.GetItemsList(), DateTimeOffset.UtcNow.AddHours(1)) as IEnumerable<SportType>;
        }

        public SportType GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
