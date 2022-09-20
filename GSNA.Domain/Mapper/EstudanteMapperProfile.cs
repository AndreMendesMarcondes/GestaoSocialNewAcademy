using AutoMapper;
using GSNA.Domain.Domain;
using GSNA.Domain.DTO.Estudante;

namespace GSNA.Domain.Mapper
{
    public class EstudanteMapperProfile : Profile
    {
        public EstudanteMapperProfile()
        {
            CreateMap<InstagramDetails, EstudanteInsertDTO>().ReverseMap();
        }
    }
}
