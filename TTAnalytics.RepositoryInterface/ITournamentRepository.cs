using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface ITournamentRepository
    {
        ICollection<Tournament> GetAll();
        Tournament Get(int id);
        Tournament Add(Tournament tournament);
        Tournament Update(Tournament tournament);
        void Delete(int id);
    }
}
