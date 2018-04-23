using System.Collections.Generic;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private TTAnalyticsContext context;

        public CategoryRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Category> GetAll()
        {
            return context.Categories
                .ToList();
        }

        public Category Get(int id)
        {
            return context.Categories
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }


        public Category Add(Category category)
        {
            var result = context.Categories.Add(category);

            Save();

            return result;
        }

        public Category Update(Category category)
        {
            context.Entry(category).State = System.Data.Entity.EntityState.Modified;

            Save();

            return category;
        }


        public void Delete(int id)
        {
            Category category = context.Categories.Find(id);
            context.Categories.Remove(category);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
