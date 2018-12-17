using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Models;

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

        public bool IsUserExis(string email)
        {
            try
            {
                using (IvhunimEntities entities = new IvhunimEntities())
                {
                    if (entities.AspNetUsers.Any(o => o.UserName == email))
                        return true;
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}