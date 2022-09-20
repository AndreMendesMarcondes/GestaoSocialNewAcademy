using AutoMapper;
using GSNA.Domain.Domain;
using GSNA.Domain.DTO;
using GSNA.Domain.Interfaces.Repositorio;
using GSNA.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GSNA.Service.Services
{
    public class InstagramDetailsService : IInstagramDetailsService
    {
        private readonly IInstagramDetailsRepositorio _repositorio;
        private readonly ILogger<InstagramDetailsService> _log;

        public InstagramDetailsService(IInstagramDetailsRepositorio repositorio,
                                       ILogger<InstagramDetailsService> log)
        {
            _repositorio = repositorio;
            _log = log;
        }

        public async Task Delete(string id)
        {
            if (await _repositorio.GetById(id) != null)
                await _repositorio.Delete(id);
        }

        public async Task<List<InstagramDetailsDTO>> GetAll()
        {
            _log.LogInformation("Buscando instagramDetailss no service");
            var listOfDomain =  await _repositorio.GetAll();
            List<InstagramDetailsDTO> list = new();

            foreach (var item in listOfDomain)
            {
                list.Add(new InstagramDetailsDTO(item));
            }

            return list;
        }

        public async Task<InstagramDetailsDTO?> GetById(string id)
        {
            var list = await _repositorio.GetById(id);

            if (list.Any())
            {
                var instagramDetail = list.FirstOrDefault();
                return new InstagramDetailsDTO(instagramDetail);
            }

            return null;
        }

        public async Task Insert(InstagramDetailsDTO instagramDetailsDTO)
        {
            try
            {
                _log.LogInformation($"Salvando instagramDetails {JsonConvert.SerializeObject(instagramDetailsDTO)} no banco de dados");
                InstagramDetails instagramDetails = new InstagramDetails(instagramDetailsDTO);

                await _repositorio.Insert(instagramDetails);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Erro ao salvar instagramDetails");
                throw;
            }
        }

        public async Task Update(string id, InstagramDetailsDTO instagramDetailsDTO)
        {
            var instagramDetails = await GetById(id);
            if (instagramDetails != null)
            {
                instagramDetailsDTO.ID = id;
                await _repositorio.Update(new InstagramDetails(instagramDetailsDTO));
            }
        }
    }
}
