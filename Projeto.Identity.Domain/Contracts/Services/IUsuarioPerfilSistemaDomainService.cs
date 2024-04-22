using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using Projeto.Identity.Domain.Models.UsuarioPerfilSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Contracts.Services
{
    public interface IUsuarioPerfilSistemaDomainService
    {
        Task<(UsuarioPerfilSistemaResponseDTO dto, string mensagem)> CreateAsync(UsuarioPerfilSistemaCadastroModel model);
        Task<(UsuarioPerfilSistemaResponseDTO dto, string mensagem)> UpdateAsync(UsuarioPerfilSistemaEdicaoModel model);
        Task<UsuarioPerfilSistemaResponseDTO> DeleteAsync(UsuarioPerfilSistemaExclusaoModel model);

        Task<List<UsuarioPerfilSistemaResponseDTO>> GetAllAsync();
        Task<List<UsuarioPerfilSistemaResponseDTO>> GetAllAsync(UsuarioPerfilSistemaRequestDTO dto);

        Task<UsuarioPerfilSistemaResponseDTO> GetByIdAsync(Guid id);

        Task<List<string>> ObterPermissoes(Guid sistemaId, Guid perfilId);
        Task<Guid?> ObterPerfilUsuario(Guid sistemaId, Guid UsuarioId);
    }
}
