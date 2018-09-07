using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace a1.Controllers
{
    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> AddUser([FromBody] User user)
        {
            using(a120180723112025asas_dbEntities entities = new a120180723112025asas_dbEntities())
            {
                //user.Id = GeneratorService.GetId();
                //user.pas
                entities.Users.Add(user);
                await entities.SaveChangesAsync();
                return Ok(this.Get());
            }
        }

        [HttpGet]
        [Route("isUserAdmin")]
        public IHttpActionResult IsUserAdmin()
        {
            return Ok(User.IsInRole("Admin"));
        }

        [HttpGet]
        [Route("getIvhunim")]
        public async Task<IHttpActionResult> Get()
        {
            using (a120180723112025asas_dbEntities entities = new a120180723112025asas_dbEntities())
            {
                var ivhunim = entities.Users;
                IEnumerable<RolesAction> roles = null;
                using (a120180723112025asas_dbEntities2 roleActionEntity = new a120180723112025asas_dbEntities2())
                {
                    roles = roleActionEntity.RolesActions;
                    if (User.IsInRole("Admin"))
                    {
                        roles = roles.Where(role => role.RoleId == 1);
                    }
                    else
                    {
                        roles = roles.Where(role => role.RoleId == -1);
                    }
                    return Ok(new IvhunimAndActions
                    {
                        Ivhunim = ivhunim.ToList(),
                        Actions = roles.ToList()
                    });
                }
            }
        }
    }
}