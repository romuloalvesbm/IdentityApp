using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using Projeto.Identity.Domain.Models.Perfil;
using Projeto.Identity.Domain.Models.PerfilPermissao;
using Projeto.Identity.Domain.Models.Permissao;
using Projeto.Identity.Domain.Models.Sistema;
using Projeto.Identity.Domain.Models.Usuario;
using Projeto.Identity.Domain.Models.UsuarioPerfilSistema;
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
        private readonly PasswordHasher<string> _passwordHasher;

        public MappingProfile(PasswordHasher<string> passwordHasher)
        {
            _passwordHasher = passwordHasher;

            #region Sistemas

            CreateMap<SistemaCadastroModel, Sistema>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => Guid.NewGuid()));

            CreateMap<SistemaEdicaoModel, Sistema>();

            CreateMap<SistemaExclusaoModel, SistemaResponseDTO>();

            CreateMap<Sistema, SistemaResponseDTO>()
                .ForMember(dest => dest.PerfilDTOs, map => map.MapFrom(src => src.Perfils))
                .ReverseMap();

            #endregion

            #region Perfil

            CreateMap<PerfilCadastroModel, Perfil>()
              .ForMember(dest => dest.Id, map => map.MapFrom(src => Guid.NewGuid()));

            CreateMap<PerfilEdicaoModel, Perfil>();

            CreateMap<PerfilExclusaoModel, PerfilResponseDTO>();

            CreateMap<Perfil, PerfilResponseDTO>()
                .ForMember(dest => dest.Sistema, map => map.MapFrom(src => src.Sistema.Nome))
                .ForMember(dest => dest.PermissaoDTOs, map => map.MapFrom(src => src.PerfilxPermissoes.Select(x => x.Permissao)))
                .ReverseMap();

            #endregion

            #region Usuario

            CreateMap<UsuarioCadastroModel, Usuario>()
             .ForMember(dest => dest.Id, map => map.MapFrom(src => Guid.NewGuid()))
             .ForMember(dest => dest.DataCriacao, map => map.MapFrom(src => DateTime.Now))
             .ForMember(dest => dest.Senha, map => map.MapFrom(src => _passwordHasher.HashPassword(null, src.Senha)));

            CreateMap<UsuarioEdicaoModel, Usuario>();

            CreateMap<UsuarioExclusaoModel, UsuarioResponseDTO>();

            CreateMap<Usuario, UsuarioResponseDTO>()
                .ForMember(dest => dest.SistemaDTO, map => map.MapFrom(src => src.UsuarioxPerfilxSistemas.Select(x=> x.Perfil.Sistema)))
                .ReverseMap();

            #endregion

            #region Permissao

            CreateMap<PermissaoCadastroModel, Permissao>()
             .ForMember(dest => dest.Id, map => map.MapFrom(src => Guid.NewGuid()));

            CreateMap<PermissaoEdicaoModel, Permissao>();

            CreateMap<PermissaoExclusaoModel, PermissaoResponseDTO>();

            CreateMap<Permissao, PermissaoResponseDTO>()
                .ReverseMap();

            #endregion

            #region Perfil_Permissao

            CreateMap<PerfilPermissaoCadastroModel, PerfilPermissao>()
                .ForMember(dest => dest.IdPerfilPermissao, map => map.MapFrom(src => Guid.NewGuid()));

            CreateMap<PerfilPermissaoEdicaoModel, PerfilPermissao>();

            CreateMap<PerfilPermissaoExclusaoModel, PerfilPermissaoResponseDTO>();

            CreateMap<PerfilPermissao, PerfilPermissaoResponseDTO>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.IdPerfilPermissao))
                .ForMember(dest => dest.Sistema, map => map.MapFrom(src => src.Perfil.Sistema.Nome))
                .ForMember(dest => dest.Perfil, map => map.MapFrom(src => src.Perfil.Nome))
                .ForMember(dest => dest.Permissao, map => map.MapFrom(src => src.Permissao.Descricao))
                .ReverseMap();

            #endregion

            #region Usuario_Perfil_Sistema

            CreateMap<UsuarioPerfilSistemaCadastroModel, UsuarioPerfilSistema>()
                .ForMember(dest => dest.IdUsuarioPerfilSistema, map => map.MapFrom(src => Guid.NewGuid()));

            CreateMap<UsuarioPerfilSistemaEdicaoModel, UsuarioPerfilSistema>();

            CreateMap<UsuarioPerfilSistemaExclusaoModel, UsuarioPerfilSistemaResponseDTO>();

            CreateMap<UsuarioPerfilSistema, UsuarioPerfilSistemaResponseDTO>()
                .ForMember(dest => dest.Usuario, map => map.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Sistema, map => map.MapFrom(src => src.Perfil.Sistema.Nome))
                .ForMember(dest => dest.Perfil, map => map.MapFrom(src => src.Perfil.Nome))
                .ReverseMap();

            CreateMap<
                UsuarioPerfilSistema, UsuarioSistemaPerfilPermissaoResponseDTO>()
              .ForMember(dest => dest.UsuarioResponseDTO, map => map.MapFrom(src => src.Usuario));

            #endregion
        }
    }
}