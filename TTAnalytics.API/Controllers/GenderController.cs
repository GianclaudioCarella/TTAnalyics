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
    /// GenderController
    /// </summary>
    [RoutePrefix("api/gender")]
    public class GenderController : ApiController
    {
        private IGenderRepository genderRepository;

        /// <summary>
        /// GenderController
        /// </summary>
        public GenderController()
        {
            genderRepository = new GenderRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// GenderController
        /// </summary>
        /// <param name="genderRepository"></param>
        public GenderController(IGenderRepository genderRepository)
        {
            this.genderRepository = genderRepository;
        }

        /// <summary>
        /// Get List of All Genders
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Genders")]
        [ResponseType(typeof(ICollection<Gender>))]
        public IHttpActionResult Get()
        {
            return Ok(genderRepository.GetAll());
        }
    }
}
