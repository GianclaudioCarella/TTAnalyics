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
    /// CountryController
    /// </summary>
    [RoutePrefix("api/country")]
    public class CountryController : ApiController
    {
        private ICountryRepository countryRepository;

        /// <summary>
        /// CountryController
        /// </summary>
        public CountryController()
        {
            countryRepository = new CountryRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// CountryController
        /// </summary>
        /// <param name="countryRepository"></param>
        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        /// <summary>
        /// Get List of All Countries
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Countries")]
        [ResponseType(typeof(ICollection<Country>))]
        public IHttpActionResult Get()
        {
            return Json(countryRepository.GetAll());
        }

        /// <summary>
        /// Get a Specific Country
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get a Specific Country")]
        [ResponseType(typeof(Country))]
        public IHttpActionResult Get(int id)
        {
            return Json(countryRepository.Get(id));
        }
    }
}