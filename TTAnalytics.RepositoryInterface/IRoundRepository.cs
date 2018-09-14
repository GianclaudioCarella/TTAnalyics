using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IRoundRepository
    {
        ICollection<Round> GetAll();
        Round Get(int id);
        Round Add(Round round);
        Round Update(Round round);
        void Delete(int id);
    }
}
