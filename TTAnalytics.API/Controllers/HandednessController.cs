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
            return Json(handednessRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Handedness by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Handedness by Id")]
        [ResponseType(typeof(Handedness))]
        public IHttpActionResult Get(int id)
        {
            return Json(handednessRepository.Get(id));
        }

        /// <summary>
        /// Add New Handedness
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Handedness")]
        [ResponseType(typeof(Handedness))]
        public IHttpActionResult Post([FromBody]Handedness handedness)
        {
            var result = new Handedness();

            if (ModelState.IsValid)
            {
                result = handednessRepository.Add(handedness);
            }

            return Json(result);
        }

        /// <summary>
        /// Edit Handedness
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Handedness")]
        [ResponseType(typeof(Handedness))]
        public IHttpActionResult Put([FromBody]Handedness handedness)
        {
            var result = new Handedness();

            if (ModelState.IsValid)
            {
                result = handednessRepository.Update(handedness);
            }

            return Json(result);
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
