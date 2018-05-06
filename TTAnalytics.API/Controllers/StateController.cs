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
    /// StateController
    /// </summary>
    public class StateController : ApiController
    {
        private IStateRepository stateRepository;

        /// <summary>
        /// StateController
        /// </summary>
        public StateController()
        {
            stateRepository = new StateRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// StateController
        /// </summary>
        /// <param name="stateRepository"></param>
        public StateController(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        /// <summary>
        /// Get List of All States
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All States")]
        [ResponseType(typeof(ICollection<State>))]
        public IHttpActionResult Get()
        {
            return Json(stateRepository.GetAll());
        }
    }
}
