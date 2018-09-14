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
    /// <summary>
    /// SponsorController
    /// </summary>
    [RoutePrefix("api/sponsor")]
    public class SponsorController : ApiController
    {
        private ISponsorRepository sponsorRepository;

        /// <summary>
        /// SponsorController
        /// </summary>
        public SponsorController()
        {
            sponsorRepository = new SponsorRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// SponsorController
        /// </summary>
        /// <param name="sponsorRepository"></param>
        public SponsorController(ISponsorRepository sponsorRepository)
        {
            this.sponsorRepository = sponsorRepository;
        }

        /// <summary>
        /// Get List of All Sponsors
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Sponsors")]
        [ResponseType(typeof(ICollection<Sponsor>))]
        public IHttpActionResult Get()
        {
            return Json(sponsorRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Sponsor by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Sponsor by Id")]
        [ResponseType(typeof(Sponsor))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Json(sponsorRepository.Get(id));
        }

        /// <summary>
        /// Add New Sponsor
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Sponsor")]
        [ResponseType(typeof(Sponsor))]
        public IHttpActionResult Post([FromBody]Sponsor sponsor)
        {
            var result = new Sponsor();

            if (ModelState.IsValid)
            {
                if (sponsor.Name == null)
                {
                    return Content(HttpStatusCode.BadRequest, "Sponsor name is empty");
                }

                result = sponsorRepository.Add(sponsor);
            }

            return Json(result);
        }

        /// <summary>
        /// Edit Sponsor
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Sponsor")]
        [ResponseType(typeof(Sponsor))]
        public IHttpActionResult Put([FromBody]Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                sponsor = sponsorRepository.Update(sponsor);
            }

            return Json(sponsor);
        }

        /// <summary>
        /// Delete Sponsor
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Sponsor")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            sponsorRepository.Delete(id);
        }
    }
}
