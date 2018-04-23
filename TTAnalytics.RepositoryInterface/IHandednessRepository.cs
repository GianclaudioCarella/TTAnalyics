using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IHandednessRepository
    {
        ICollection<Handedness> GetAll();
        Handedness Get(int id);
        Handedness Add(Handedness handedness);
        Handedness Update(Handedness handedness);
        void Delete(int id);
    }
}
