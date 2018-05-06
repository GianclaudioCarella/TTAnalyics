using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.Repository;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.API.Controllers
{
    /// <summary>
    /// CategoryController
    /// </summary>
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        private ICategoryRepository categoryRepository;

        /// <summary>
        /// CategoryController
        /// </summary>
        public CategoryController()
        {
            categoryRepository = new CategoryRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// CategoryController
        /// </summary>
        /// <param name="categoryRepository"></param>
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Get List of All Categories
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Categories")]
        [ResponseType(typeof(ICollection<Category>))]
        public IHttpActionResult Get()
        {
            return Json(categoryRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Category by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Category by Id")]
        [ResponseType(typeof(Category))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Json(categoryRepository.Get(id));
        }

        /// <summary>
        /// Add New Category
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Category")]
        [ResponseType(typeof(Category))]
        public IHttpActionResult Post([FromBody]Category category)
        {
            var result = new Category();

            if (ModelState.IsValid)
            {
                categoryRepository.Add(category);
            }

            return Json(result);
        }

        /// <summary>
        /// Edit Category
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Category")]
        [ResponseType(typeof(Category))]
        public IHttpActionResult Put([FromBody]Category category)
        {
            var result = new Category();

            if (ModelState.IsValid)
            {
                result = categoryRepository.Update(category);
            }

            return Json(result);
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Category")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            categoryRepository.Delete(id);
        }
    }
}
