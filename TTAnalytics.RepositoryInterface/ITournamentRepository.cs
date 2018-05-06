using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface ITournamentRepository
    {
        ICollection<Tournament> GetAll();
        Tournament Get(int id);
        ICollection<Category> GetCategories(int id);
        Tournament Add(Tournament tournament);
        Category AddCategory(int tournamentId, Category category);
        Tournament Update(Tournament tournament);
        void Delete(int id);
    }
}
