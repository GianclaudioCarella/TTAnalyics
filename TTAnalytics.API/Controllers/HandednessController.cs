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
    /// HandednessController
    /// </summary>
    [RoutePrefix("api/handedness")]
    public class HandednessController : ApiController
    {
        private IHandednessRepository handednessRepository;

        /// <summary>
        /// HandednessController
        /// </summary>
        public HandednessController()
        {
            handednessRepository = new HandednessRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// HandednessController
        /// </summary>
        /// <param name="handednessRepository"></param>
        public HandednessController(IHandednessRepository handednessRepository)
        {
            this.handednessRepository = handednessRepository;
        }

        /// <summary>
        /// Get List of All Handedness
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Handedness")]
        [ResponseType(typeof(ICollection<Handedness>))]
        public IHttpActionResult Get()
        {
            return Ok(handednessRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Handedness by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Handedness by Id")]
        [ResponseType(typeof(Handedness))]
        public IHttpActionResult Get(int id)
        {
            return Ok(handednessRepository.Get(id));
        }

        /// <summary>
        /// Add New Handedness
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Handedness")]
        [ResponseType(typeof(void))]
        public void Post([FromBody]Handedness handedness)
        {
            if (ModelState.IsValid)
            {
                handednessRepository.Add(handedness);
            }
        }

        /// <summary>
        /// Edit Handedness
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Handedness")]
        [ResponseType(typeof(void))]
        public void Put([FromBody]Handedness handedness)
        {
            if (ModelState.IsValid)
            {
                handednessRepository.Update(handedness);
            }
        }

        /// <summary>
        /// Delete Handedness
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Handedness")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            handednessRepository.Delete(id);
        }
    }
}
