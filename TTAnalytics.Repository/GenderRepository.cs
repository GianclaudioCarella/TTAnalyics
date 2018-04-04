using System.Collections.Generic;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class GenderRepository : IGenderRepository
    {
        private TTAnalyticsContext context;

        public GenderRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Gender> GetAll()
        {
            return context.Genders.ToList();
        }
    }
}
