using GSNA.Domain.Domain;
using GSNA.Domain.DTO.Estudante;

namespace GSNA.Domain.Interfaces.Services
{
    public interface IEstudanteService
    {
        Task<List<InstagramDetails>> GetAll();
        Task Insert(EstudanteInsertDTO estudante);
        Task<InstagramDetails?> GetById(string id);
        Task Update(string id, EstudanteInsertDTO estudante);
        Task Delete(string id);
    }
}
