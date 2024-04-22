using AutoMapper;
using Projeto.Identity.Domain.Contracts.Repositories;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using Projeto.Identity.Domain.Models.PerfilPermissao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Services
{
    public class PerfilPermissaoDomainService : IPerfilPermissaoDomainService
    {
        private readonly IMapper _mapper;
        private readonly IPerfilRepository _perfilRepository;        
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly IPerfilPermissaoRepository _perfilPermissaoRepository;

        public PerfilPermissaoDomainService(IMapper mapper, IPerfilRepository perfilRepository, IPermissaoRepository permissaoRepository, IPerfilPermissaoRepository perfilPermissaoRepository)
        {
            _mapper = mapper;
            _perfilRepository = perfilRepository;
            _permissaoRepository = permissaoRepository;
            _perfilPermissaoRepository = perfilPermissaoRepository;
        }

        public async Task<(PerfilPermissaoResponseDTO dto, string mensagem)> CreateAsync(PerfilPermissaoCadastroModel model)
        {
            try
            {
                if (!await _perfilRepository.AnyAsync(x => x.Id == model.PerfilId && x.SistemaId == model.SistemaId))
                    return (new PerfilPermissaoResponseDTO(), "Perfil não encontrado no sistema selecionado.");

                if (!await _permissaoRepository.AnyAsync(x => x.Id == model.PermissaoId))
                    return (new PerfilPermissaoResponseDTO(), "Permissão não encontrado.");

                var perfilPermissao = _mapper.Map<PerfilPermissao>(model);
                await _perfilPermissaoRepository.CreateAsync(perfilPermissao);

                return (_mapper.Map<PerfilPermissaoResponseDTO>(perfilPermissao), string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }        

        public async Task<PerfilPermissaoResponseDTO> DeleteAsync(PerfilPermissaoExclusaoModel model)
        {
            try
            {
                var perfilPermissao = await _perfilPermissaoRepository.GetByIdAsync(model.Id);

                if (perfilPermissao != null)
                {
                    await _perfilPermissaoRepository.DeleteAsync(perfilPermissao);
                }

                return _mapper.Map<PerfilPermissaoResponseDTO>(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PerfilPermissaoResponseDTO>> GetAllAsync()
        {
            try
            {
                var aaa = await _perfilPermissaoRepository.GetAllAsync();
                return _mapper.Map<List<PerfilPermissaoResponseDTO>>(await _perfilPermissaoRepository.GetAllAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PerfilPermissaoResponseDTO>> GetAllAsync(PerfilPermissaoRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<PerfilPermissaoResponseDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
