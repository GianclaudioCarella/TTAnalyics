using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IClubRepository
    {
        ICollection<Club> GetAll();
        Club Get(int id);
        Club Add(Club club);
        Club Update(Club club);
        void Delete(int id);
    }
}
