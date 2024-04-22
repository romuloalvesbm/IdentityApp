using AutoMapper;
using Projeto.Identity.Domain.Contracts.Repositories;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using Projeto.Identity.Domain.Models.UsuarioPerfilSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Services
{
    public class UsuarioPerfilSistemaDomainService : IUsuarioPerfilSistemaDomainService
    {
        private readonly IMapper _mapper;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUsuarioPerfilSistemaRepository _usuarioPerfilSistemaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioPerfilSistemaDomainService(IMapper mapper, IPerfilRepository perfilRepository, IUsuarioPerfilSistemaRepository usuarioPerfilSistemaRepository, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _perfilRepository = perfilRepository;
            _usuarioPerfilSistemaRepository = usuarioPerfilSistemaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<(UsuarioPerfilSistemaResponseDTO dto, string mensagem)> CreateAsync(UsuarioPerfilSistemaCadastroModel model)
        {
            try
            {
                if (!await _perfilRepository.AnyAsync(x => x.Id == model.PerfilId && x.SistemaId == model.SistemaId))
                    return (new UsuarioPerfilSistemaResponseDTO(), "Perfil não encontrado no sistema selecionado.");

                if (!await _usuarioRepository.AnyAsync(x => x.Id == model.UsuarioId))
                    return (new UsuarioPerfilSistemaResponseDTO(), "Usuário não encontrado.");

                var usuarioPerfilPermissao = _mapper.Map<UsuarioPerfilSistema>(model);
                await _usuarioPerfilSistemaRepository.CreateAsync(usuarioPerfilPermissao);

                return (_mapper.Map<UsuarioPerfilSistemaResponseDTO>(usuarioPerfilPermissao), string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UsuarioPerfilSistemaResponseDTO> DeleteAsync(UsuarioPerfilSistemaExclusaoModel model)
        {
            try
            {
                var usuarioPerfilPermissao = await _usuarioPerfilSistemaRepository.GetByIdAsync(model.IdUsuarioPerfilSistema);

                if (usuarioPerfilPermissao != null)
                {
                    await _usuarioPerfilSistemaRepository.DeleteAsync(usuarioPerfilPermissao);
                }

                return _mapper.Map<UsuarioPerfilSistemaResponseDTO>(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UsuarioPerfilSistemaResponseDTO>> GetAllAsync()
        {
            try
            {               
                return _mapper.Map<List<UsuarioPerfilSistemaResponseDTO>>(await _usuarioPerfilSistemaRepository.GetAllAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<List<UsuarioPerfilSistemaResponseDTO>> GetAllAsync(UsuarioPerfilSistemaRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioPerfilSistemaResponseDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid?> ObterPerfilUsuario(Guid sistemaId, Guid UsuarioId)
        {
            return await _usuarioPerfilSistemaRepository.ObterPerfilUsuario(sistemaId, UsuarioId);
        }

        public async Task<List<string>> ObterPermissoes(Guid sistemaId, Guid perfilId)
        {
            return await _usuarioPerfilSistemaRepository.ObterPermissoes(sistemaId, perfilId);         
        }

        public Task<(UsuarioPerfilSistemaResponseDTO dto, string mensagem)> UpdateAsync(UsuarioPerfilSistemaEdicaoModel model)
        {
            throw new NotImplementedException();
        }
    }
}
