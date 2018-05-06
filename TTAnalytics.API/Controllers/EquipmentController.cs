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
    /// EquipmentController
    /// </summary>
    [RoutePrefix("api/equipment")]
    public class EquipmentController : ApiController
    {
        private IEquipmentRepository equipmentRepository;

        /// <summary>
        /// EquipmentController
        /// </summary>
        public EquipmentController()
        {
            equipmentRepository = new EquipmentRepository(new TTAnalyticsContext());
        }

        /// <summary>
        /// EquipmentController
        /// </summary>
        /// <param name="equipmentRepository"></param>
        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            this.equipmentRepository = equipmentRepository;
        }

        /// <summary>
        /// Get List of All Equipments
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Equipments")]
        [ResponseType(typeof(ICollection<Equipment>))]
        public IHttpActionResult Get()
        {
            return Json(equipmentRepository.GetAll());
        }

        /// <summary>
        /// Get Specific Equipment by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific Equipment by Id")]
        [ResponseType(typeof(Equipment))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Json(equipmentRepository.Get(id));
        }

        /// <summary>
        /// Add New Equipment
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New Equipment")]
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult Post([FromBody]Equipment equipment)
        {
            var result = new Equipment();

            if (ModelState.IsValid)
            {
                result = equipmentRepository.Add(equipment);
            }

            return Json(result);
        }

        /// <summary>
        /// Edit Equipment
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit Equipment")]
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult Put([FromBody]Equipment equipment)
        {
            var result = new Equipment();

            if (ModelState.IsValid)
            {
                result = equipmentRepository.Update(equipment);
            }

            return Json(result);
        }

        /// <summary>
        /// Delete Equipment
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete Equipment")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            equipmentRepository.Delete(id);
        }
    }
}
