using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IOrganizerRepository
    {
        ICollection<Organizer> GetAll();
        Organizer Get(int id);
        void Add(Organizer organizer);
        void Update(Organizer organizer);
        void Delete(int id);
    }
}
