using Models;

namespace BusinessLogickLayer.Interfaces
{
    public interface IUserService : IService<User>
    {
        User GetMatchingUser(string login);
    }
}
