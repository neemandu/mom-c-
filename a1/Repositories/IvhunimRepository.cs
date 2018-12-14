using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace a1.Repositories
{
    public class IvhunimRepository : IIvhunimRepository
    {
        public async Task Delete(int id)
        {
            using (Ivhun entities = new Ivhun())
            {
                var ivhunToDelete = entities.Ivhunims.Where(user => user.Id == id).SingleOrDefault();
                if (ivhunToDelete != null)
                {
                    entities.Ivhunims.Remove(ivhunToDelete);
                    await entities.SaveChangesAsync();
                }

            }
        }

        public async Task Duplicate(int id)
        {
            try
            {
                using (Ivhun entities = new Ivhun())
                {
                    var ivhunToCopy = entities.Ivhunims.AsNoTracking().Where(user => user.Id == id).SingleOrDefault();
                    if (ivhunToCopy != null)
                    {
                        ivhunToCopy.FirstName = ivhunToCopy.FirstName + " - העתק";
                        entities.Ivhunims.Add(ivhunToCopy);
                        await entities.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Post(Ivhunim ivhun)
        {
            try
            {
                using (Ivhun entities = new Ivhun())
                {
                    entities.Ivhunims.Add(ivhun);
                    await entities.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IvhunimAndActions> GetAll(bool isUserAdmin)
        {
            using (Ivhun entities = new Ivhun())
            {
                var ivhunim = entities.Ivhunims;
                IEnumerable<RolesAction> roles = null;
                using (a120180723112025asas_dbEntities2 roleActionEntity = new a120180723112025asas_dbEntities2())
                {
                    roles = roleActionEntity.RolesActions;
                    if (isUserAdmin)
                    {
                        roles = roles.Where(role => role.RoleId == 1);
                    }
                    else
                    {
                        roles = roles.Where(role => role.RoleId == -1);
                    }
                    var result = new IvhunimAndActions
                    {
                        Ivhunim = ivhunim.ToList(),
                        Actions = roles.ToList()
                    };
                    return result;
                }
            }
        }
    }
}