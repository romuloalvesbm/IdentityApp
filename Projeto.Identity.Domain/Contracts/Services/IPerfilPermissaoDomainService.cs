using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.PerfilPermissao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Contracts.Services
{
    public interface IPerfilPermissaoDomainService
    {
        Task<(PerfilPermissaoResponseDTO dto, string mensagem)> CreateAsync(PerfilPermissaoCadastroModel model);        
        Task<PerfilPermissaoResponseDTO> DeleteAsync(PerfilPermissaoExclusaoModel model);

        Task<List<PerfilPermissaoResponseDTO>> GetAllAsync();
        Task<List<PerfilPermissaoResponseDTO>> GetAllAsync(PerfilPermissaoRequestDTO dto);

        Task<PerfilPermissaoResponseDTO> GetByIdAsync(Guid id);
    }
}
