using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Contracts.Services
{
    public interface ISistemaDomainService
    {
        Task<(SistemaResponseDTO dto, string mensagem)> CreateAsync(SistemaCadastroModel model);
        Task<(SistemaResponseDTO dto, string mensagem)> UpdateAsync(SistemaEdicaoModel model);
        Task<SistemaResponseDTO> DeleteAsync(SistemaExclusaoModel model);

        Task<List<SistemaResponseDTO>> GetAllAsync();
        Task<List<SistemaResponseDTO>> GetAllAsync(SistemaRequestDTO dto);

        Task<SistemaResponseDTO> GetByIdAsync(Guid id);

    }
}

