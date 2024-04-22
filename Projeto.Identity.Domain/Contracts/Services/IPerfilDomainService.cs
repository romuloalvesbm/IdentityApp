using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Contracts.Services
{
    public interface IPerfilDomainService
    {
        Task<(PerfilResponseDTO dto, string mensagem)> CreateAsync(PerfilCadastroModel model);
        Task<(PerfilResponseDTO dto, string mensagem)> UpdateAsync(PerfilEdicaoModel model);
        Task<PerfilResponseDTO> DeleteAsync(PerfilExclusaoModel model);

        Task<List<PerfilResponseDTO>> GetAllAsync();
        Task<List<PerfilResponseDTO>> GetAllAsync(PerfilRequestDTO dto);

        Task<PerfilResponseDTO> GetByIdAsync(Guid id);
    }
}
