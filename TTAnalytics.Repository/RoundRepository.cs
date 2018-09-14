using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class RoundRepository : IRoundRepository
    {
        private TTAnalyticsContext context;

        public RoundRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Round> GetAll()
        {
            return context.Round
                .ToList();
        }

        public Round Get(int id)
        {
            return context.Round
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }


        public Round Add(Round round)
        {
            var result = context.Round.Add(round);

            Save();

            return result;
        }

        public Round Update(Round round)
        {
            context.Entry(round).State = EntityState.Modified;

            Save();

            return round;
        }


        public void Delete(int id)
        {
            Round round = context.Round.Find(id);
            context.Round.Remove(round);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
