using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetAll();
        Category Get(int id);
        Category Add(Category category);
        Category Update(Category category);
        void Delete(int id);
    }
}
