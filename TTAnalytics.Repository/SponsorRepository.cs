using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class SponsorRepository : ISponsorRepository
    {
        private TTAnalyticsContext context;

        public SponsorRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Sponsor> GetAll()
        {
            return context.Sponsors
                .ToList();
        }

        public Sponsor Get(int id)
        {
            return context.Sponsors
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }


        public Sponsor Add(Sponsor sponsor)
        {
            var result = context.Sponsors.Add(sponsor);

            Save();

            return result;
        }

        public Sponsor Update(Sponsor sponsor)
        {
            context.Entry(sponsor).State = EntityState.Modified;

            Save();

            return sponsor;
        }


        public void Delete(int id)
        {
            Sponsor sponsor = context.Sponsors.Find(id);
            context.Sponsors.Remove(sponsor);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
