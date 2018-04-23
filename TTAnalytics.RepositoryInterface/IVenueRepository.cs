using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IVenueRepository
    {
        ICollection<Venue> GetAll();
        Venue Get(int id);
        Venue Add(Venue venue);
        Venue Update(Venue venue);
        void Delete(int id);
    }
}
