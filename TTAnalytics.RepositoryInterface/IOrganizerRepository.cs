using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IOrganizerRepository
    {
        ICollection<Organizer> GetAll();
        Organizer Get(int id);
        Organizer Add(Organizer organizer);
        Organizer Update(Organizer organizer);
        void Delete(int id);
    }
}
