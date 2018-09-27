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
    [RoutePrefix("api/ivhunim")]
    public class IvhunimController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IvhunimAndActions Get()
        {
            using (a120180723112025asas_dbEntities entities = new a120180723112025asas_dbEntities())
            {
                var ivhunim = entities.Users;
                IEnumerable<RolesAction> roles = null;
                using (a120180723112025asas_dbEntities2 roleActionEntity = new a120180723112025asas_dbEntities2())
                {
                    roles = roleActionEntity.RolesActions;
                    if (IsUserAdmin())
                    {
                        roles = roles.Where(role => role.RoleId == 1);
                    }
                    else
                    {
                        roles = roles.Where(role => role.RoleId == -1);
                    }
                    return new IvhunimAndActions
                    {
                        Ivhunim = ivhunim.ToList(),
                        Actions = roles.ToList()
                    };
                }
            }
        }

        private bool IsUserAdmin()
        {
            bool isAdmin = User.IsInRole("Admin");
            return true;//isAdmin;
        }

        [HttpGet]
        [Route("download/{id}")]
        public IHttpActionResult Download(int id)
        {
            return Ok();
        }
        [HttpPut]
        [Route("duplicate/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Duplicate(int id)
        {
            try
            {
                using (a120180723112025asas_dbEntities entities = new a120180723112025asas_dbEntities())
                {
                    var ivhunToCopy = entities.Users.Where(user => user.Id == id).SingleOrDefault();
                    if (ivhunToCopy == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        var newIvhun = new User(ivhunToCopy);
                        newIvhun.FirstName = newIvhun.FirstName + " - העתק";

                        return await this.Post(newIvhun);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("email/{id}")]
        [Authorize(Roles = "Admin")]
        public string EmailClient(int id)
        {
            return "value";
        }

        [HttpPut]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Post([FromBody]User newIvhun)
        {
            try
            {
                using (a120180723112025asas_dbEntities entities = new a120180723112025asas_dbEntities())
                {
                    entities.Users.Add(newIvhun);
                    await entities.SaveChangesAsync();
                    return Ok(this.Get());
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]User newIvhun)
        {
            try
            {
                await Delete(id);
                return await Post(newIvhun);               
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                using (a120180723112025asas_dbEntities entities = new a120180723112025asas_dbEntities())
                {
                    var ivhunToDelete = entities.Users.Where(user => user.Id == id).SingleOrDefault();
                    if (ivhunToDelete == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        entities.Users.Remove(ivhunToDelete);
                        await entities.SaveChangesAsync();
                        return Ok(this.Get());
                    }

                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}