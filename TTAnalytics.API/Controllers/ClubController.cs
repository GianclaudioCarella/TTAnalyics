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
    [RoutePrefix("api/club")]
    public class ClubController : ApiController
    {
        private IClubRepository clubRepository;
        private IPlayerRepository playerRepository;

        public ClubController()
        {
            clubRepository = new ClubRepository(new TTAnalyticsContext());
            playerRepository = new PlayerRepository(new TTAnalyticsContext());
        }

        public ClubController(IClubRepository clubRepository, IPlayerRepository playerRepository)
        {
            this.clubRepository = clubRepository;
            this.playerRepository = playerRepository;
        }

        /// <summary>
        /// Get List of All Clubs
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Clubs")]
        [ResponseType(typeof(ICollection<Club>))]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(clubRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Club by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Club by Id")]
        [ResponseType(typeof(Club))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(clubRepository.Get(id));
        }

        /// <summary>
        /// Get List of All Players from a Club
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Players from a Club")]
        [ResponseType(typeof(ICollection<Club>))]
        [Route("{id:int}/players")]
        public IHttpActionResult GetClubPlayers(int id)
        {
            return Ok(playerRepository.GetByClub(id));
        }

        /// <summary>
        /// Add New Club
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Club")]
        [ResponseType(typeof(void))]
        [Route("")]
        public void Post([FromBody]Club club)
        {
            if (ModelState.IsValid)
            {
                clubRepository.Add(club);
            }
        }

        /// <summary>
        /// Edit Club
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Club")]
        [ResponseType(typeof(void))]
        [Route("")]
        public void Put([FromBody]Club club)
        {
            if (ModelState.IsValid)
            {
                clubRepository.Update(club);
            }
        }

        /// <summary>
        /// Delete Club
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Club")]
        [ResponseType(typeof(void))]
        [Route("")]
        public void Delete(int id)
        {
            clubRepository.Delete(id);
        }
    }
}