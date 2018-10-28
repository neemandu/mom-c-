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
        //[Authorize(Roles = "Admin")]
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
        //[Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> EmailClient(int id)
        {
            using (a120180723112025asas_dbEntities entities = new a120180723112025asas_dbEntities())
            {
                var ivhunim = entities.Users.Where(o => o.Id == id).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(ivhunim.Email))
                {
                    return NotFound();
                }
                else
                {
                    var fromAddress = new MailAddress("neemanaya@gmail.com", "איה נאמן");
                    var toAddress = new MailAddress(ivhunim.Email, ivhunim.FirstName + " " + ivhunim.LastName);
                    const string fromPassword = "52345865";
                    const string subject = "איה נאמן - אבחון";
                    string body = $@"שלום,
.האבחון של ילד/תך מוכן
:בכדי להוריד את האבחון, כנס ל
ayaneeman.azurewebsites.net
{ivhunim.Email} :שם המשתמש
blabla :סיסמא
לשאלות נוספות, ניתן להשיב לאימייל הזה או להתקשר אלי לטלפון: 0522204509";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                }
            }
            return Ok();
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
            catch (Exception ex)
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