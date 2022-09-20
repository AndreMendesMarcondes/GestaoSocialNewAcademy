using AutoMapper;
using GSNA.Domain.Domain;
using GSNA.Domain.DTO.Estudante;
using GSNA.Domain.Interfaces.Repositorio;
using GSNA.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GSNA.Service.Services
{
    public class EstudanteService : IEstudanteService
    {
        private readonly IEstudanteRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<EstudanteService> _log;

        public EstudanteService(IEstudanteRepositorio repositorio,
                                IMapper mapper,
                                ILogger<EstudanteService> log)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _log = log;
        }

        public async Task Delete(string id)
        {
            if (await _repositorio.GetById(id) != null)
                await _repositorio.Delete(id);
        }

        public async Task<List<InstagramDetails>> GetAll()
        {
            _log.LogInformation("Buscando estudantes no service");
            return await _repositorio.GetAll();
        }

        public async Task<InstagramDetails?> GetById(string id)
        {
            var list = await _repositorio.GetById(id);

            if (list.Any())
                return list.FirstOrDefault();

            return null;
        }

        public async Task Insert(EstudanteInsertDTO estudanteDTO)
        {
            try
            {
                _log.LogInformation($"Salvando estudante {JsonConvert.SerializeObject(estudanteDTO)} no banco de dados");
                InstagramDetails estudante = _mapper.Map<InstagramDetails>(estudanteDTO);

                _log.LogInformation($"Estudante mapeado com sucesso {JsonConvert.SerializeObject(estudante)}s");
                await _repositorio.Insert(estudante);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Erro ao salvar estudante");
                throw;
            }
        }

        public async Task Update(string id, EstudanteInsertDTO estudanteDTO)
        {
            var estudante = await GetById(id);
            if (estudante != null)
            {
                estudante = _mapper.Map<InstagramDetails>(estudanteDTO);
                estudante.Id = id;

                await _repositorio.Update(estudante);
            }
        }
    }
}
