using System.Collections.Generic;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private TTAnalyticsContext context;

        public CountryRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Country> GetAll()
        {
            return context.Country.ToList();
        }

        public Country Get(int id)
        {
            return context.Country.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
