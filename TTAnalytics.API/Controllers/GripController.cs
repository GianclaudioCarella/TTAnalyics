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
    public class GripController : ApiController
    {
        private IGripRepository gripRepository;

        public GripController()
        {
            gripRepository = new GripRepository(new TTAnalyticsContext());
        }

        public GripController(IGripRepository gripRepository)
        {
            this.gripRepository = gripRepository;
        }

        /// <summary>
        /// Get List of All Grips
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Players")]
        [ResponseType(typeof(ICollection<Grip>))]
        public IHttpActionResult Get()
        {
            return Ok(gripRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Grip by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Grip by Id")]
        [ResponseType(typeof(Grip))]
        public IHttpActionResult Get(int id)
        {
            return Ok(gripRepository.Get(id));
        }

        /// <summary>
        /// Add New Grip
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Grip")]
        [ResponseType(typeof(void))]
        public void Post([FromBody]Grip grip)
        {
            if (ModelState.IsValid)
            {
                gripRepository.Add(grip);
            }
        }

        /// <summary>
        /// Edit Grip
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Grip")]
        [ResponseType(typeof(void))]
        public void Put([FromBody]Grip grip)
        {
            if (ModelState.IsValid)
            {
                gripRepository.Update(grip);
            }
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
