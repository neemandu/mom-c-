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

        public IvhunimAndActions GetAll(bool isUserAdmin, bool isUserNextStepAdmin, bool isUserTypist, string email)
        {
            using (IvhunimEntities entities = new IvhunimEntities())
            {
                var ivhunim = new List<Ivhunim>();
                var columns = new List<RolesMainTableColumns>();
                IEnumerable<RolesActions> roles = null;
                roles = entities.RolesActionss;
                if (isUserAdmin)
                {
                    roles = roles.Where(role => role.RoleId == 1);
                    ivhunim = entities.Ivhunims.ToList();
                    foreach (var column in entities.RolesMainTableColumns.Where(role => role.RoleId == 1).OrderByDescending(o => o.OrderNumber))
                    {
                        columns.Add(column);
                    }
                }
                else if (isUserNextStepAdmin)
                {
                    roles = roles.Where(role => role.RoleId == 3);
                    foreach(var ivhun in entities.Ivhunims.Where(ivhun => ivhun.Institue == InstituesNames.NEXT_STEP))
                    {
                        ivhunim.Add(ivhun);
                    }
                    foreach(var column in entities.RolesMainTableColumns.Where(role => role.RoleId == 3).OrderByDescending(o => o.OrderNumber))
                    {
                        columns.Add(column);
                    }
                }
                else if (isUserTypist)
                {
                    roles = roles.Where(role => role.RoleId == 4);
                    ivhunim = entities.Ivhunims.ToList();
                    foreach (var column in entities.RolesMainTableColumns.Where(role => role.RoleId == 4).OrderByDescending(o => o.OrderNumber))
                    {
                        columns.Add(column);
                    }
                }
                else
                {
                    roles = roles.Where(role => role.RoleId == -1);
                    foreach (var ivhun in entities.Ivhunims.Where(ivhun => ivhun.ParentEmail == email && ivhun.ReadyToBeSent == true))
                    {
                        ivhunim.Add(ivhun);
                    }
                    foreach (var column in entities.RolesMainTableColumns.Where(role => role.RoleId == -1).OrderByDescending(o => o.OrderNumber))
                    {
                        columns.Add(column);
                    }
                }
                var result = new IvhunimAndActions
                {
                    Ivhunim = ivhunim,
                    Actions = roles.ToList(),
                    Columns = columns.Select(o => o.ColumnName).ToList()
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