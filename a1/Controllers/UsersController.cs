using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
using System.Net.Mail;

namespace a1.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("IsUserAdmin")]
        public IHttpActionResult IsUserAdmin()
        {
            bool isAdmin = User.IsInRole("Admin");
            return Ok(isAdmin);
        }
    }
}