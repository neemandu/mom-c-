using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace a1.Controllers
{
    public class RolesController : ApiController
    {
        public IEnumerable<AspNetRole> Get()
        {
            using(a120180723112025asas_dbEntities1 entities = new a120180723112025asas_dbEntities1())
            {
                return entities.AspNetRoles.ToList();
            }
        }
    }
}
