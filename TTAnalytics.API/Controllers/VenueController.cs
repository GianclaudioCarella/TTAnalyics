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
    public class VenueController : ApiController
    {
        private IVenueRepository venueRepository;

        public VenueController()
        {
            venueRepository = new VenueRepository(new TTAnalyticsContext());
        }

        public VenueController(IVenueRepository venueRepository)
        {
            this.venueRepository = venueRepository;
        }

        /// <summary>
        /// Get List of All Venues
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Venues")]
        [ResponseType(typeof(ICollection<Venue>))]
        public IHttpActionResult Get()
        {
            return Ok(venueRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Venue by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Venue by Id")]
        [ResponseType(typeof(Venue))]
        public IHttpActionResult Get(int id)
        {
            return Ok(venueRepository.Get(id));
        }

        /// <summary>
        /// Add New Venue
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Venue")]
        [ResponseType(typeof(void))]
        public void Post([FromBody]Venue venue)
        {
            if (ModelState.IsValid)
            {
                venueRepository.Add(venue);
            }
        }

        /// <summary>
        /// Edit Venue
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Venue")]
        [ResponseType(typeof(void))]
        public void Put([FromBody]Venue venue)
        {
            if (ModelState.IsValid)
            {
                venueRepository.Update(venue);
            }
        }

        /// <summary>
        /// Delete Venue
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Venue")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            venueRepository.Delete(id);
        }

    }
}
