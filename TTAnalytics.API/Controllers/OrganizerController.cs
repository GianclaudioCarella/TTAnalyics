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
    public class OrganizerController : ApiController
    {
        private IOrganizerRepository organizerRepository;

        public OrganizerController()
        {
            organizerRepository = new OrganizerRepository(new TTAnalyticsContext());
        }

        public OrganizerController(IOrganizerRepository organizerRepository)
        {
            this.organizerRepository = organizerRepository;
        }

        /// <summary>
        /// Get List of All Organizers
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Organizers")]
        [ResponseType(typeof(ICollection<Organizer>))]
        public IHttpActionResult Get()
        {
            return Ok(organizerRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Organizer by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Organizer by Id")]
        [ResponseType(typeof(Organizer))]
        public IHttpActionResult Get(int id)
        {
            return Ok(organizerRepository.Get(id));
        }

        /// <summary>
        /// Add New Organizer
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Organizer")]
        [ResponseType(typeof(void))]
        public void Post([FromBody]Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                organizerRepository.Add(organizer);
            }
        }

        /// <summary>
        /// Edit Organizer
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Organizer")]
        [ResponseType(typeof(void))]
        public void Put([FromBody]Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                organizerRepository.Update(organizer);
            }
        }

        /// <summary>
        /// Delete Organizer
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Organizer")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            organizerRepository.Delete(id);
        }

    }
}
