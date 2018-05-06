using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.Repository;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.API.Controllers
{
    /// <summary>
    /// TournamentController
    /// </summary>
    [RoutePrefix("api/tournament")]
    public class TournamentController : ApiController
    {
        private ITournamentRepository tournamentRepository;
        private IOrganizerRepository organizerRepository;
        private IVenueRepository venueRepository;
        private ICategoryRepository categoryRepository;

        /// <summary>
        /// TournamentController
        /// </summary>
        public TournamentController()
        {
            tournamentRepository = new TournamentRepository(new TTAnalyticsContext(), organizerRepository, categoryRepository, venueRepository);
        }

        /// <summary>
        /// TournamentController
        /// </summary>
        /// <param name="tournamentRepository"></param>
        /// <param name="organizerRepository"></param>
        /// <param name="venueRepository"></param>
        /// <param name="categoryRepository"></param>
        public TournamentController(ITournamentRepository tournamentRepository, IOrganizerRepository organizerRepository, IVenueRepository venueRepository, ICategoryRepository categoryRepository)
        {
            this.tournamentRepository = tournamentRepository;
            this.organizerRepository = organizerRepository;
            this.categoryRepository = categoryRepository;
            this.venueRepository = venueRepository;
        }

        /// <summary>
        /// Get List of All Tournaments
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Tournaments")]
        [ResponseType(typeof(ICollection<Tournament>))]
        public IHttpActionResult Get()
        {
            return Json(tournamentRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Tournament by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Tournament by Id")]
        [ResponseType(typeof(Tournament))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Json(tournamentRepository.Get(id));
        }

        /// <summary>
        /// Add New Tournament
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Tournament")]
        [ResponseType(typeof(Tournament))]
        public IHttpActionResult Post([FromBody]Tournament tournament)
        {
            var result = new Tournament();

            if (ModelState.IsValid)
            {
                if (tournament.Organizer == null)
                {
                    return Content(HttpStatusCode.BadRequest, "Organizer is empty");
                }

                if (tournament.Organizer.Id == 0 || organizerRepository.Get(tournament.Organizer.Id) == null)
                {
                    return Content(HttpStatusCode.NotFound, "Organizer not found");
                }

                if (tournament.Venue == null)
                {
                    return Content(HttpStatusCode.BadRequest, "Venue is empty");
                }

                if (tournament.Venue.Id == 0 || venueRepository.Get(tournament.Venue.Id) == null)
                {
                    return Content(HttpStatusCode.NotFound, "Venue not found");
                }

                result = tournamentRepository.Add(tournament);
            }

            return Json(result);
        }

        /// <summary>
        /// Create a new Category into the Tournament
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <param name="categories"></param>
        /// <returns></returns>
        [SwaggerOperation("Create a new Category into the Tournament")]
        [ResponseType(typeof(Category))]
        [Route("{id:int}/categories")]
        [HttpPost]
        public IHttpActionResult PostCategories(int tournamentId, [FromBody]ICollection<Category> categories)
        {
            var result = new List<Category>();

            if (ModelState.IsValid)
            {
                foreach (Category category in categories)
                {
                    result.Add(tournamentRepository.AddCategory(tournamentId, category));
                }
            }

            return Json(result);
        }

        /// <summary>
        /// Get List of Tournament Categories
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        [SwaggerOperation("Get List of Tournament Categories")]
        [ResponseType(typeof(ICollection<Category>))]
        [Route("{id:int}/categories")]
        [HttpGet]
        public IHttpActionResult GetCategories(int tournamentId)
        {
            return Json(tournamentRepository.GetCategories(tournamentId));
        }

        /// <summary>
        /// Edit Tournament
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Tournament")]
        [ResponseType(typeof(Tournament))]
        public IHttpActionResult Put([FromBody]Tournament tournament)
        {
            var result = new Tournament();

            if (ModelState.IsValid)
            {
                result = tournamentRepository.Update(tournament);
            }

            return Json(result);
        }

        /// <summary>
        /// Delete Tournament
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Tournament")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            tournamentRepository.Delete(id);
        }
    }
}
