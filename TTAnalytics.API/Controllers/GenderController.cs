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
    public class GenderController : ApiController
    {
        private IGenderRepository genderRepository;

        public GenderController()
        {
            genderRepository = new GenderRepository(new TTAnalyticsContext());
        }

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
