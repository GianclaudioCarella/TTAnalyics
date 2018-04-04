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
    public class UserController : ApiController
    {
        private IUserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository(new TTAnalyticsContext());
        }

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Get List of All Users
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get List of All Users")]
        [ResponseType(typeof(ICollection<User>))]
        public IHttpActionResult Get()
        {
            return Ok(userRepository.GetAll());
        }

        /// <summary>
        /// Get Specific User by Id
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get Specific User by Id")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            return Ok(userRepository.Get(id));
        }

        /// <summary>
        /// Add New User
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Add New User")]
        [ResponseType(typeof(void))]
        public void Post([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Add(user);
            }
        }

        /// <summary>
        /// Edit User
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Edit User")]
        [ResponseType(typeof(void))]
        public void Put([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Update(user);
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Delete User")]
        [ResponseType(typeof(void))]
        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
    }
}
