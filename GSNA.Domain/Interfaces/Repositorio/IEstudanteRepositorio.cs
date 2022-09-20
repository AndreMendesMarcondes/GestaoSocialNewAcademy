using GSNA.Domain.Domain;

namespace GSNA.Domain.Interfaces.Repositorio
{
    public interface IEstudanteRepositorio
    {
        Task<List<InstagramDetails>> GetAll();
        Task<List<InstagramDetails>> GetById(string id);
        Task Update(InstagramDetails estudante);
        Task Delete(string id);
        Task Insert(InstagramDetails estudante);
    }
}
