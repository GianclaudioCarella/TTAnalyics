using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IEquipmentRepository
    {
        ICollection<Equipment> GetAll();
        Equipment Get(int id);
        Equipment Add(Equipment equipment);
        Equipment Update(Equipment equipment);
        void Delete(int id);
    }
}
