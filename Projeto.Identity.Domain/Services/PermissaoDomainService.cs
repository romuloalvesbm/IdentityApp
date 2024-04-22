using AutoMapper;
using Projeto.Identity.Domain.Contracts.Repositories;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using Projeto.Identity.Domain.Models.Permissao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Services
{
    public class PermissaoDomainService : IPermissaoDomainService
    {
        private readonly IMapper _mapper;
        private readonly IPermissaoRepository _permissaoRepository;

        public PermissaoDomainService(IMapper mapper, IPermissaoRepository permissaoRepository)
        {
            _mapper = mapper;
            _permissaoRepository = permissaoRepository;
        }

        public async Task<(PermissaoResponseDTO dto, string mensagem)> CreateAsync(PermissaoCadastroModel model)
        {
            try
            {
                if (await _permissaoRepository.AnyAsync(x => x.ChaveAutorizacao == model.ChaveAutorizacao))
                    return (new PermissaoResponseDTO(), "Permissão já cadastrada.");

                var permissao = _mapper.Map<Permissao>(model);
                await _permissaoRepository.CreateAsync(permissao);

                return (_mapper.Map<PermissaoResponseDTO>(permissao), string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PermissaoResponseDTO> DeleteAsync(PermissaoExclusaoModel model)
        {
            try
            {
                var permissao = await _permissaoRepository.GetByIdAsync(model.Id);

                if (permissao != null)
                {
                    await _permissaoRepository.DeleteAsync(permissao);
                }               

                return _mapper.Map<PermissaoResponseDTO>(model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<(PermissaoResponseDTO dto, string mensagem)> UpdateAsync(PermissaoEdicaoModel model)
        {
            try
            {
                var permissao = await _permissaoRepository.GetByIdAsync(model.Id);

                if (permissao == null)
                    return (new PermissaoResponseDTO(), "Permissão não encontrada.");

                _mapper.Map(model, permissao);

                await _permissaoRepository.UpdateAsync(permissao);

                return (_mapper.Map<PermissaoResponseDTO>(permissao), string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PermissaoResponseDTO>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<List<PermissaoResponseDTO>>(await _permissaoRepository.GetAllAsync());

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PermissaoResponseDTO>> GetAllAsync(PermissaoRequestDTO dto)
        {
            try
            {
                return _mapper.Map<List<PermissaoResponseDTO>>(await _permissaoRepository.GetAllAsync(x => (string.IsNullOrEmpty(dto.Id) || x.Id == Guid.Parse(dto.Id)) &&
                                                                                                       (string.IsNullOrEmpty(dto.Descricao) || x.Descricao == dto.Descricao)));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PermissaoResponseDTO> GetByIdAsync(Guid id)
        {
            try
            {
                return _mapper.Map<PermissaoResponseDTO>(await _permissaoRepository.GetByIdAsync(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
