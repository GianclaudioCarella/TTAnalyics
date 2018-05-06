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
    /// GripController
    /// </summary>
    [RoutePrefix("api/grip")]
    public class GripController : ApiController
    {
        private IGripRepository gripRepository;

        /// <summary>
        /// GripController
        /// </summary>
        public GripController()
        {
            gripRepository = new GripRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// GripController
        /// </summary>
        /// <param name="gripRepository"></param>
        public GripController(IGripRepository gripRepository)
        {
            this.gripRepository = gripRepository;
        }

        /// <summary>
        /// Get List of All Grips
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Grips")]
        [ResponseType(typeof(ICollection<Grip>))]
        public IHttpActionResult Get()
        {
            return Json(gripRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Grip by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Grip by Id")]
        [ResponseType(typeof(Grip))]
        public IHttpActionResult Get(int id)
        {
            return Json(gripRepository.Get(id));
        }

        /// <summary>
        /// Add New Grip
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Grip")]
        [ResponseType(typeof(Grip))]
        public IHttpActionResult Post([FromBody]Grip grip)
        {
            var result = new Grip();

            if (ModelState.IsValid)
            {
                result = gripRepository.Add(grip);
            }

            return Json(result);
        }

        /// <summary>
        /// Edit Grip
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Grip")]
        [ResponseType(typeof(Grip))]
        public IHttpActionResult Put([FromBody]Grip grip)
        {
            var result = new Grip();

            if (ModelState.IsValid)
            {
                result = gripRepository.Update(grip);
            }

            return Json(result);
        }

        /// <summary>
        /// Delete Grip
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Grip")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            gripRepository.Delete(id);
        }
    }
}
