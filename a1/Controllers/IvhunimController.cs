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
using a1.Repositories;

namespace a1.Controllers
{
    [Authorize]
    [RoutePrefix("api/ivhunim")]
    public class IvhunimController : ApiController
    {
        private IIvhunimRepository _ivhunRpo;

        public IvhunimController()
        {
            _ivhunRpo = new IvhunimRepository();
        }
        // GET api/<controller>
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                bool isUserAdmin = IsUserAdmin();
                var result = await _ivhunRpo.GetAll(isUserAdmin);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return InternalServerError();
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
                await _ivhunRpo.Duplicate(id);
                return Ok(await _ivhunRpo.GetAll(IsUserAdmin()));
            }
            catch (Exception ex)
            {
                return InternalServerError();
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
                return Ok(await _ivhunRpo.GetAll(IsUserAdmin()));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await _ivhunRpo.Delete(id);
                return Ok(await _ivhunRpo.GetAll(IsUserAdmin()));                
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}