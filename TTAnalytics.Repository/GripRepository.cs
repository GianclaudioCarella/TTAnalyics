using System.Collections.Generic;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class GripRepository : IGripRepository
    {
        private TTAnalyticsContext context;

        public GripRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Grip> GetAll()
        {
            return context.Grips.ToList();
        }

        public Grip Get(int id)
        {
            return context.Grips.Where(p => p.Id == id).FirstOrDefault();
        }


        public void Add(Grip grip)
        {
            context.Grips.Add(grip);

            Save();
        }

        public void Update(Grip grip)
        {
            context.Entry(grip).State = System.Data.Entity.EntityState.Modified;

            Save();
        }


        public void Delete(int id)
        {
            Grip grip = context.Grips.Find(id);
            context.Grips.Remove(grip);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
