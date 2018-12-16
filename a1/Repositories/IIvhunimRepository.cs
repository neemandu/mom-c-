using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace a1.Repositories
{
    public interface IIvhunimRepository
    {
        Task Delete(int id);
        Task Duplicate(int id);
        Task Post(Ivhunim ivhun);
        Task Upsert(Ivhunim ivhun);
        Task<IvhunimAndActions> GetAll(bool isUserAdmin);
    }
}