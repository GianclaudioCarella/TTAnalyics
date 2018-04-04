using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IGenderRepository
    {
        ICollection<Gender> GetAll();
    }
}
