using System.Collections.Generic;
using System.Linq;
using TTAnalytics.Data;
using System.Data.Entity;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class StateRepository : IStateRepository
    {
        private TTAnalyticsContext context;

        public StateRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<State> GetAll()
        {
            return context.States
                .Include(s => s.Country)
                .ToList();
        }
    }
}
