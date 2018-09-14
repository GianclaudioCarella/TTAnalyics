using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IMatchRepository
    {
        ICollection<Match> GetAll();
        Match Get(int id);
        Match Add(Match match);
        Match Update(Match match);
        void Delete(int id);
    }
}
