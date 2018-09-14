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
    /// RoundController
    /// </summary>
    [RoutePrefix("api/round")]
    public class RoundController : ApiController
    {
        private IRoundRepository roundRepository;

        /// <summary>
        /// RoundController
        /// </summary>
        public RoundController()
        {
            roundRepository = new RoundRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// RoundController
        /// </summary>
        /// <param name="roundRepository"></param>
        public RoundController(IRoundRepository roundRepository)
        {
            this.roundRepository = roundRepository;
        }

        /// <summary>
        /// Get List of All Rounds
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Rounds")]
        [ResponseType(typeof(ICollection<Round>))]
        public IHttpActionResult Get()
        {
            return Json(roundRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Round by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Round by Id")]
        [ResponseType(typeof(Round))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Json(roundRepository.Get(id));
        }
        
        /// <summary>
        /// Add New Round
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Round")]
        [ResponseType(typeof(Round))]
        public IHttpActionResult Post([FromBody]Round round)
        {
            var result = new Round();

            if (ModelState.IsValid)
            {
                if (round.Name == null)
                {
                    return Content(HttpStatusCode.BadRequest, "Round name is empty");
                }
                
                result = roundRepository.Add(round);
            }

            return Json(result);
        }

        /// <summary>
        /// Edit Round
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Round")]
        [ResponseType(typeof(Round))]
        public IHttpActionResult Put([FromBody]Round round)
        {
            if (ModelState.IsValid)
            {
                round = roundRepository.Update(round);
            }

            return Json(round);
        }

        /// <summary>
        /// Delete Round
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Round")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            roundRepository.Delete(id);
        }
    }
}
