using GSNA.Domain.Domain;

namespace GSNA.Domain.Interfaces.Repositorio
{
    public interface IInstagramDetailsRepositorio
    {
        Task<List<InstagramDetails>> GetAll();
        Task<List<InstagramDetails>> GetById(string id);
        Task Update(InstagramDetails instagramDetails);
        Task Delete(string id);
        Task Insert(InstagramDetails instagramDetails);
    }
}
