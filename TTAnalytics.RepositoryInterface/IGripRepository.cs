using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IGripRepository
    {
        ICollection<Grip> GetAll();
        Grip Get(int id);
        void Add(Grip grip);
        void Update(Grip grip);
        void Delete(int id);
    }
}
