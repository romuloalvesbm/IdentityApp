using AutoMapper;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using Projeto.Identity.Domain.Models.Perfil;
using Projeto.Identity.Domain.Models.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projeto.Identity.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Sistemas

            CreateMap<SistemaCadastroModel, Sistema>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => Guid.NewGuid()));

            CreateMap<SistemaEdicaoModel, Sistema>();

            CreateMap<Sistema, SistemaResponseDTO>()
                .ForMember(dest => dest.PerfilDTO, map => map.MapFrom(src => src.Perfils))
                .ReverseMap();

            CreateMap<PerfilCadastroModel, Perfil>()
               .ForMember(dest => dest.Id, map => map.MapFrom(src => Guid.NewGuid()));

            CreateMap<PerfilEdicaoModel, Perfil>();

            CreateMap<Perfil, PerfilResponseDTO>()
                .ForMember(dest => dest.Sistema, map => map.MapFrom(src => src.Sistema.Nome))
                .ReverseMap();

            #endregion


        }
    }
}