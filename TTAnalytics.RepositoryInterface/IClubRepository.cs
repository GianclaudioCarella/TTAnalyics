using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IClubRepository
    {
        ICollection<Club> GetAll();
        Club Get(int id);
        void Add(Club club);
        void Update(Club club);
        void Delete(int id);
    }
}
