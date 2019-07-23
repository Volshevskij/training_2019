using Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetMatchingUser(string login);
    }
}
