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
            return Ok(tournamentRepository.GetAll());
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
            return Ok(tournamentRepository.Get(id));
        }

        /// <summary>
        /// Add New Tournament
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Tournament")]
        [ResponseType(typeof(void))]
        public void Post([FromBody]Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                tournamentRepository.Add(tournament);
            }
        }

        /// <summary>
        /// Edit Tournament
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Tournament")]
        [ResponseType(typeof(void))]
        public void Put([FromBody]Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                tournamentRepository.Update(tournament);
            }
        }

        /// <summary>
        /// Delete Tournament
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Tournament")]
        [ResponseType(typeof(void))]
        [Route("")]
        public void Delete(int id)
        {
            tournamentRepository.Delete(id);
        }
    }
}
