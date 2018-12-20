using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Models;
using Contracts;

namespace a1.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private IUserRepository _usrRepo;

        public UsersController(IUserRepository usrRepo)
        {
            _usrRepo = usrRepo;
        }

        [HttpGet]
        [Route("IsUserAdmin")]
        public IHttpActionResult IsUserAdmin()
        {
            bool isAdmin = User.IsInRole("Admin");
            return Ok(isAdmin);
        }

        [HttpGet]
        [Route("isUserExists/{id}")]
        public IHttpActionResult IsUserExist(int id)
        {
            try
            {
                return Ok(_usrRepo.IsUserExis(id));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}