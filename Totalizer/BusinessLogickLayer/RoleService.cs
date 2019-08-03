using BusinessLogickLayer.Cacher;
using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class RoleService : IRoleService
    {
        IRoleRepository repository;
        IMemoryCacher memoryCacher;

        public RoleService(IRoleRepository _repository, IMemoryCacher _memoryCacher)
        {
            repository = _repository;
            memoryCacher = _memoryCacher;
        }

        public void CreateItem(Role role)
        {
            memoryCacher.Delete("role");
            repository.CreateItem(role);
        }

        public void UpdateItem(Role role)
        {
            memoryCacher.Delete("role");
            repository.UpdateItem(role);
        }

        public void DeleteItem(int id)
        {
            memoryCacher.Delete("role");
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
