﻿using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Mail;
using a1.Repositories;
using Models;

namespace a1.Controllers
{
    [Authorize]
    [RoutePrefix("api/ivhunim")]
    public class IvhunimController : ApiController
    {
        private IIvhunimRepository _ivhunRpo;
        private IIvhunimService _ivhunimSrv;
        
        public IvhunimController(IIvhunimRepository ivhunRpo,
                                 IIvhunimService ivhunimSrv)
        {
            _ivhunRpo = ivhunRpo;
            _ivhunimSrv = ivhunimSrv;

        }
        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                bool isUserAdmin = IsUserAdmin();
                var result = _ivhunRpo.GetAll(isUserAdmin);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private bool IsUserAdmin()
        {
            bool isAdmin = User.IsInRole("Admin");
            return isAdmin;
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
                await _ivhunRpo.Duplicate(id);
                return Ok(_ivhunRpo.GetAll(IsUserAdmin()));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("email/{id}/{password}")]
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult EmailClient([FromUri] int id, [FromUri] string password)
        {
            try
            {

                using (IvhunimEntities entities = new IvhunimEntities())
                {

                    var ivhunim = entities.Ivhunims.Where(o => o.Id == id).FirstOrDefault();

                    string body = "";
                   if (string.IsNullOrWhiteSpace(password))
                    {
                        body = $@"שלום,
האבחון של ילד/תך מוכן.
בכדי להוריד את האבחון, כנס/י ל: 
ayaneeman.azurewebsites.net
'התחבר/י עם שם המשתמש והסיסמא שלך ולחצ/י על - 'האבחונים שלי.
לשאלות נוספות, ניתן להשיב לאימייל הזה או להתקשר אלי לטלפון: 0522204509";  
                    }
                    else
                    {
                        body = $@"שלום,
האבחון של ילד/תך מוכן.
בכדי להוריד את האבחון, כנס/י ל: 
ayaneeman.azurewebsites.net
שם המשתמש: {ivhunim.ParentEmail}
סיסמא: {password}
לשאלות נוספות, ניתן להשיב לאימייל הזה או להתקשר אלי לטלפון: 0522204509";
                    }
                    

                    if (string.IsNullOrWhiteSpace(ivhunim.ParentEmail))
                    {
                        return NotFound();
                    }
                    else
                    {
                        var fromAddress = new MailAddress("neemanaya@gmail.com", "איה נאמן");
                        var toAddress = new MailAddress(ivhunim.ParentEmail, ivhunim.FirstName + " " + ivhunim.LastName);
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
                            Body = body,
                            IsBodyHtml = false                            
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
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPost]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Upsert(int id, [FromBody]Ivhunim ivhun)
        {
            try
            {
                if (id > -1)
                {
                    ivhun.Id = id;
                    await _ivhunRpo.Upsert(ivhun);
                }
                else
                {
                    await _ivhunRpo.Post(ivhun);
                }
                return Ok(_ivhunRpo.GetAll(IsUserAdmin()));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await _ivhunRpo.Delete(id);
                return Ok(_ivhunRpo.GetAll(IsUserAdmin()));                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}