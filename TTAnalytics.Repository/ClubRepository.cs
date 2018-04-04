using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class ClubRepository : IClubRepository
    {
        private TTAnalyticsContext context;

        public ClubRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Club> GetAll()
        {
            return context.Clubs
                .Include(c => c.Country)
                .ToList();
        }

        public Club Get(int id)
        {
            return context.Clubs
                .Where(p => p.Id == id)
                .Include(c => c.Country)
                .FirstOrDefault();
        }


        public void Add(Club club)
        {
            context.Clubs.Add(club);

            Save();
        }

        public void Update(Club club)
        {
            context.Entry(club).State = System.Data.Entity.EntityState.Modified;

            Save();
        }


        public void Delete(int id)
        {
            Club club = context.Clubs.Find(id);
            context.Clubs.Remove(club);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
