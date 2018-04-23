using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IUserRepository
    {
        ICollection<User> GetAll();
        User Get(int id);
        User Add(User user);
        User Update(User user);
        void Delete(int id);
    }
}
