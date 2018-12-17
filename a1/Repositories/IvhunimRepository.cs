using a1.Models;
using Models;
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
            using (IvhunimEntities entities = new IvhunimEntities())
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
                using (IvhunimEntities entities = new IvhunimEntities())
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
                using (IvhunimEntities entities = new IvhunimEntities())
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

        public IvhunimAndActions GetAll(bool isUserAdmin)
        {
            using (IvhunimEntities entities = new IvhunimEntities())
            {
                var ivhunim = entities.Ivhunims;
                IEnumerable<RolesActions> roles = null;
                roles = entities.RolesActionss;
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

        public async Task Upsert(Ivhunim ivhun)
        {

            try
            {
                using (IvhunimEntities entities = new IvhunimEntities())
                {
                    entities.Entry(ivhun).State = System.Data.Entity.EntityState.Modified;
                    await entities.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}