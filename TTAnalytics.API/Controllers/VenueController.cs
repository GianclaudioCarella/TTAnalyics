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

        /// <summary>
        /// VenueController
        /// </summary>
        public VenueController()
        {
            venueRepository = new VenueRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// VenueController
        /// </summary>
        /// <param name="venueRepository"></param>
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
            return Json(venueRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Venue by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Venue by Id")]
        [ResponseType(typeof(Venue))]
        public IHttpActionResult Get(int id)
        {
            return Json(venueRepository.Get(id));
        }

        /// <summary>
        /// Add New Venue
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Venue")]
        [ResponseType(typeof(Venue))]
        public IHttpActionResult Post([FromBody]Venue venue)
        {
            var result = new Venue();

            if (ModelState.IsValid)
            {
                result = venueRepository.Add(venue);
            }

            return Json(result);
        }

        /// <summary>
        /// Edit Venue
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Venue")]
        [ResponseType(typeof(Venue))]
        public IHttpActionResult Put([FromBody]Venue venue)
        {
            var result = new Venue();

            if (ModelState.IsValid)
            {
                result = venueRepository.Update(venue);
            }

            return Json(result);
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
