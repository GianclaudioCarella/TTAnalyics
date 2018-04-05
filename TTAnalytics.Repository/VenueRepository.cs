using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class VenueRepository : IVenueRepository
    {
        private TTAnalyticsContext context;

        public VenueRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Venue> GetAll()
        {
            return context.Venues
                .Include(v => v.State)
                .ToList();
        }

        public Venue Get(int id)
        {
            return context.Venues
                .Where(p => p.Id == id)
                .Include(v => v.State)
                .FirstOrDefault();
        }


        public void Add(Venue venue)
        {
            context.Venues.Add(venue);

            Save();
        }

        public void Update(Venue venue)
        {
            context.Entry(venue).State = EntityState.Modified;

            Save();
        }


        public void Delete(int id)
        {
            Venue venue = context.Venues.Find(id);
            context.Venues.Remove(venue);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
