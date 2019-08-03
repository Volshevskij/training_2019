using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class UserService : IUserService
    {
        IUserRepository repository;

        public UserService(IUserRepository _repository)
        {
            repository = _repository;
        }

        public void CreateItem(User user)
        {
            repository.CreateItem(user);
        }

        public void UpdateItem(User user)
        {
            repository.UpdateItem(user);
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public IEnumerable<User> GetItemsList()
        {
            return repository.GetItemsList();
        }

        public User GetItemById(int id)
        {
            return repository.GetItemById(id);
        }

        public User GetMatchingUser(string login)
        {
            return repository.GetMatchingUser(login);
        }
    }
}
