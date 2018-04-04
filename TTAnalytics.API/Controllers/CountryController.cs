using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.Repository;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.API.Controllers
{
    public class CountryController : ApiController
    {
        private ICountryRepository countryRepository;

        public CountryController()
        {
            countryRepository = new CountryRepository(new TTAnalyticsContext());
        }

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
            return Ok(countryRepository.GetAll());
        }
    }
}