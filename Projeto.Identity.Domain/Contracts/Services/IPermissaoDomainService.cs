using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Permissao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Contracts.Services
{
    public interface IPermissaoDomainService
    {
        Task<(PermissaoResponseDTO dto, string mensagem)> CreateAsync(PermissaoCadastroModel model);
        Task<(PermissaoResponseDTO dto, string mensagem)> UpdateAsync(PermissaoEdicaoModel model);
        Task<PermissaoResponseDTO> DeleteAsync(PermissaoExclusaoModel model);

        Task<List<PermissaoResponseDTO>> GetAllAsync();
        Task<List<PermissaoResponseDTO>> GetAllAsync(PermissaoRequestDTO dto);

        Task<PermissaoResponseDTO> GetByIdAsync(Guid id);
    }
}
