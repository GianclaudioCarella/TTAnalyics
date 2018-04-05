using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IStateRepository
    {
        ICollection<State> GetAll();
    }
}
