using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class RoleService:IRoleService
    {
        IRepository<Role> repository;

        public RoleService(IRepository<Role> _repository)
        {
            repository = _repository;
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
            return repository.GetItemsList();
        }

        public Role GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
