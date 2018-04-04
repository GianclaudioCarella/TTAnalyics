using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface ICountryRepository
    {
        ICollection<Country> GetAll();
    }
}
