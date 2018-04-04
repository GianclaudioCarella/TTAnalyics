using System.Collections.Generic;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class HandednessRepository : IHandednessRepository
    {
        private TTAnalyticsContext context;

        public HandednessRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Handedness> GetAll()
        {
            return context.Handedness.ToList();
        }

        public Handedness Get(int id)
        {
            return context.Handedness.Where(p => p.Id == id).FirstOrDefault();
        }


        public void Add(Handedness handedness)
        {
            context.Handedness.Add(handedness);

            Save();
        }

        public void Update(Handedness handedness)
        {
            context.Entry(handedness).State = System.Data.Entity.EntityState.Modified;

            Save();
        }


        public void Delete(int id)
        {
            Handedness handedness = context.Handedness.Find(id);
            context.Handedness.Remove(handedness);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
