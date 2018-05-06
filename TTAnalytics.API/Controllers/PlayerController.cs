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
    /// PlayerController
    /// </summary>
    public class PlayerController : ApiController
    {
        private IPlayerRepository playerRepository;

        /// <summary>
        /// PlayerController
        /// </summary>
        public PlayerController()
        {
            playerRepository = new PlayerRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// PlayerController
        /// </summary>
        /// <param name="playerRepository"></param>
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
            return Json(playerRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Player by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Player by Id")]
        [ResponseType(typeof(Player))]
        public IHttpActionResult Get(int id)
        {
            return Json(playerRepository.Get(id));
        }

        /// <summary>
        /// Add New Player
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Player")]
        [ResponseType(typeof(Player))]
        public IHttpActionResult Post([FromBody]Player player)
        {
            var result = new Player();

            if (ModelState.IsValid)
            {
                if (player.Club == null)
                {
                    return Content(HttpStatusCode.BadRequest, "Club is empty");
                }

                if (player.Country == null)
                {
                    return Content(HttpStatusCode.BadRequest, "Country is empty");
                }

                if (player.Gender == null)
                {
                    return Content(HttpStatusCode.BadRequest, "Gender is empty");
                }
                
                result = playerRepository.Add(player);
            }

            return Json(result);
        }

        /// <summary>
        /// Edit Player
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Player")]
        [ResponseType(typeof(Player))]
        public IHttpActionResult Put([FromBody]Player player)
        {
            var result = new Player();
            
            if (ModelState.IsValid)
            {
                result = playerRepository.Update(player);
            }

            return Json(result);
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