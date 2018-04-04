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
    public class PlayerController : ApiController
    {
        private IPlayerRepository playerRepository;

        public PlayerController()
        {
            playerRepository = new PlayerRepository(new TTAnalyticsContext());
        }

        public PlayerController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        /// <summary>
        /// Get List of All Players
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Players")]
        [ResponseType(typeof(ICollection<Player>))]
        public IHttpActionResult Get()
        {
            return Ok(playerRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Player by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Player by Id")]
        [ResponseType(typeof(Player))]
        public IHttpActionResult Get(int id)
        {
            return Ok(playerRepository.Get(id));
        }

        /// <summary>
        /// Add New Player
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Player")]
        [ResponseType(typeof(void))]
        public void Post([FromBody]Player player)
        {
            if (ModelState.IsValid)
            {
                playerRepository.Add(player);
            }
        }

        /// <summary>
        /// Edit Player
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Player")]
        [ResponseType(typeof(void))]
        public void Put([FromBody]Player player)
        {
            if (ModelState.IsValid)
            {
                playerRepository.Update(player);
            }
        }

        /// <summary>
        /// Delete Player
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Player")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            playerRepository.Delete(id);
        }
    }
}