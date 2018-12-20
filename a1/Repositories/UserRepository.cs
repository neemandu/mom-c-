using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace a1.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool IsUserExis(int id)
        {
            using (IvhunimEntities entities = new IvhunimEntities())
            {
                var ivhun = entities.Ivhunims.Where(o => o.Id == id).SingleOrDefault();
                if (ivhun != null && entities.AspNetUsers.Any(o => o.UserName == ivhun.ParentEmail))
                    return true;
                return false;
            }
        }
    }
}