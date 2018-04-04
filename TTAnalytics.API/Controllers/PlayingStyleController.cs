using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.Repository;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.API.Controllers
{
    public class PlayingStyleController : ApiController
    {
        private IPlayingStyleRepository playingStyleRepository;

        public PlayingStyleController()
        {
            playingStyleRepository = new PlayingStyleRepository(new TTAnalyticsContext());
        }

        public PlayingStyleController(IPlayingStyleRepository playingStyleRepository)
        {
            this.playingStyleRepository = playingStyleRepository;
        }

        /// <summary>
        /// Get List of All Playing Styles
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Playing Styles")]
        [ResponseType(typeof(ICollection<PlayingStyle>))]
        public IHttpActionResult Get()
        {
            return Ok(playingStyleRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Playing Style by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Playing Style by Id")]
        [ResponseType(typeof(Handedness))]
        public IHttpActionResult Get(int id)
        {
            return Ok(playingStyleRepository.Get(id));
        }

        /// <summary>
        /// Add New Playing Style
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Playing Style")]
        [ResponseType(typeof(void))]
        public void Post([FromBody]PlayingStyle playingStyle)
        {
            if (ModelState.IsValid)
            {
                playingStyleRepository.Add(playingStyle);
            }
        }

        /// <summary>
        /// Edit Playing Style
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Playing Style")]
        [ResponseType(typeof(void))]
        public void Put([FromBody]PlayingStyle playingStyle)
        {
            if (ModelState.IsValid)
            {
                playingStyleRepository.Update(playingStyle);
            }
        }

        /// <summary>
        /// Delete Playing Style
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Playing Style")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            playingStyleRepository.Delete(id);
        }
    }
}
