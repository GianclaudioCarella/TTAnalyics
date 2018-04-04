using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IHandednessRepository
    {
        ICollection<Handedness> GetAll();
        Handedness Get(int id);
        void Add(Handedness handedness);
        void Update(Handedness handedness);
        void Delete(int id);
    }
}
