using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Sistema;
using Projeto.Identity.Domain.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Contracts.Services
{
    public interface IUsuarioDomainService
    {
        Task<(UsuarioResponseDTO dto, string mensagem)> CreateAsync(UsuarioCadastroModel model);
        Task<(UsuarioResponseDTO dto, string mensagem)> UpdateAsync(UsuarioEdicaoModel model);
        Task<UsuarioResponseDTO> DeleteAsync(UsuarioExclusaoModel model);

        Task<List<UsuarioResponseDTO>> GetAllAsync();
        Task<List<UsuarioResponseDTO>> GetAllAsync(UsuarioRequestDTO dto);

        Task<UsuarioResponseDTO> GetByIdAsync(Guid id);
        Task<UsuarioResponseDTO> GetByEmailAsync(string email);
        bool VerifyPassword(string hashedPassword, string password);
    }
}
