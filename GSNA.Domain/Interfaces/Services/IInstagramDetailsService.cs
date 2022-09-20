using GSNA.Domain.Domain;
using GSNA.Domain.DTO;

namespace GSNA.Domain.Interfaces.Services
{
    public interface IInstagramDetailsService
    {
        Task<List<InstagramDetailsDTO>> GetAll();
        Task<InstagramDetailsDTO?> GetById(string id);
        Task Update(string id, InstagramDetailsDTO instagramDetailsDTO);
        Task Delete(string id);
        Task Insert(InstagramDetailsDTO instagramDetailsDTO);
    }
}
