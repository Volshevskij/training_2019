using BusinessLogickLayer.Cacher;
using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class RoleService:IRoleService
    {
        IRepository<Role> repository;
        IMemoryCacher memoryCacher;

        public RoleService(IRepository<Role> _repository, IMemoryCacher _memoryCacher)
        {
            repository = _repository;
            memoryCacher = _memoryCacher;
        }

        public void CreateItem(Role role)
        {
            repository.CreateItem(role);
        }

        public void UpdateItem(Role role)
        {
            repository.UpdateItem(role);
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public IEnumerable<Role> GetItemsList()
        {
            return memoryCacher.CheckCache("role", repository.GetItemsList(), DateTimeOffset.UtcNow.AddHours(1)) as IEnumerable<Role>;
        }

        public Role GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
