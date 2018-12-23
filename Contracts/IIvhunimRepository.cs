using Models;
using System.Threading.Tasks;

namespace a1.Repositories
{
    public interface IIvhunimRepository
    {
        Task Delete(int id);
        Task Duplicate(int id);
        Task Post(Ivhunim ivhun);
        Task Upsert(Ivhunim ivhun);
        IvhunimAndActions GetAll(bool isUserAdmin, bool isUserNextStepAdmin, bool isUserTypist, string email);
    }
}