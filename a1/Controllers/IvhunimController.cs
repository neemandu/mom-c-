﻿using a1.Models;
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
            using (Ivhun entities = new Ivhun())
            {
                var ivhunim = entities.Ivhunims;
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
                using (Ivhun entities = new Ivhun())
                {
                    var ivhunToCopy = entities.Ivhunims.AsNoTracking().Where(user => user.Id == id).SingleOrDefault();
                    if (ivhunToCopy == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ivhunToCopy.FirstName = "העתק - " + ivhunToCopy.FirstName;
                        entities.Ivhunims.Add(ivhunToCopy);
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

        [HttpPut]
        [Route("email/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> EmailClient(int id)
        {
            try
            {
                AccountController accounts = new AccountController();
                UsersController users = new UsersController();


                using (Ivhun entities = new Ivhun())
                {

                    var ivhunim = entities.Ivhunims.Where(o => o.Id == id).FirstOrDefault();

                    string body = "";
                    bool isUserExists = users.IsUserExis(ivhunim.Email);
                    if (isUserExists)
                    {
                        body = $@"שלום,
.האבחון של ילד/תך מוכן
:בכדי להוריד את האבחון, כנס/י ל
ayaneeman.azurewebsites.net
.'התחבר/י עם שם המשתמש והסיסמא שלך ולחצ/י על - 'האבחונים שלי
לשאלות נוספות, ניתן להשיב לאימייל הזה או להתקשר אלי לטלפון: 0522204509";  
                    }
                    else
                    {
                        string guid = Guid.NewGuid().ToString();

                        await accounts.Register(new RegisterBindingModel
                        {
                            Email = ivhunim.Email,
                            Password = guid,
                            ConfirmPassword = guid
                        });

                        body = $@"שלום,
.האבחון של ילד/תך מוכן
:בכדי להוריד את האבחון, כנס ל
ayaneeman.azurewebsites.net
{ivhunim.Email} :שם המשתמש
{guid}:סיסמא
לשאלות נוספות, ניתן להשיב לאימייל הזה או להתקשר אלי לטלפון: 0522204509";
                    }
                    

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
            catch(Exception ex)
            {
                return InternalServerError(new Exception("שגיאה - אנא נסה שנית"));
            }
        }

        [HttpPut]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Post([FromBody]Ivhunim newIvhun)
        {
            try
            {
                using (Ivhun entities = new Ivhun())
                {
                    entities.Ivhunims.Add(newIvhun);
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
        public async Task<IHttpActionResult> Put(int id, [FromBody]Ivhunim newIvhun)
        {
            try
            {
                if (id > -1)
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
                using (Ivhun entities = new Ivhun())
                {
                    var ivhunToDelete = entities.Ivhunims.Where(user => user.Id == id).SingleOrDefault();
                    if (ivhunToDelete == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        entities.Ivhunims.Remove(ivhunToDelete);
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