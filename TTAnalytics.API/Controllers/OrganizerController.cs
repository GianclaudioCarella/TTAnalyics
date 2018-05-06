﻿using Swashbuckle.Swagger.Annotations;
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
    /// OrganizerController
    /// </summary>
    [RoutePrefix("api/organizer")]
    public class OrganizerController : ApiController
    {
        private IOrganizerRepository organizerRepository;

        /// <summary>
        /// OrganizerController
        /// </summary>
        public OrganizerController()
        {
            organizerRepository = new OrganizerRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// OrganizerController
        /// </summary>
        /// <param name="organizerRepository"></param>
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
            return Json(organizerRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Organizer by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Organizer by Id")]
        [ResponseType(typeof(Organizer))]
        public IHttpActionResult Get(int id)
        {
            return Json(organizerRepository.Get(id));
        }

        /// <summary>
        /// Add New Organizer
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Organizer")]
        [ResponseType(typeof(Organizer))]
        public IHttpActionResult Post([FromBody]Organizer organizer)
        {
            var result = new Organizer();

            if (ModelState.IsValid)
            {
                result = organizerRepository.Add(organizer);
            }

            return Json(result);
        }

        /// <summary>
        /// Edit Organizer
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Organizer")]
        [ResponseType(typeof(Organizer))]
        public IHttpActionResult Put([FromBody]Organizer organizer)
        {
            var result = new Organizer();

            if (ModelState.IsValid)
            {
                result = organizerRepository.Update(organizer);
            }

            return Json(result);
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
