using System.Collections.Generic;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private TTAnalyticsContext context;

        public EquipmentRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Equipment> GetAll()
        {
            return context.Equipments
                .ToList();
        }

        public Equipment Get(int id)
        {
            return context.Equipments
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }


        public Equipment Add(Equipment equipment)
        {
            var result = context.Equipments.Add(equipment);

            Save();

            return result;
        }

        public Equipment Update(Equipment equipment)
        {
            context.Entry(equipment).State = System.Data.Entity.EntityState.Modified;

            Save();

            return equipment;
        }


        public void Delete(int id)
        {
            Equipment equipment = context.Equipments.Find(id);
            context.Equipments.Remove(equipment);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
