using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface ISponsorRepository
    {
        ICollection<Sponsor> GetAll();
        Sponsor Get(int id);
        Sponsor Add(Sponsor sponsor);
        Sponsor Update(Sponsor sponsor);
        void Delete(int id);
    }
}
