using AutoMapper;
using Projeto.Identity.Domain.Contracts.Repositories;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using Projeto.Identity.Domain.Models.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Services
{
    public class SistemaDomainService : ISistemaDomainService
    {
        private readonly IMapper _mapper;
        private readonly ISistemaRepository _sistemaRepository;

        public SistemaDomainService(IMapper mapper, ISistemaRepository sistemaRepository)
        {
            _mapper = mapper;
            _sistemaRepository = sistemaRepository;
        }

        public async Task<(SistemaResponseDTO dto, string mensagem)> CreateAsync(SistemaCadastroModel model)
        {
            try
            {
                if (await _sistemaRepository.AnyAsync(x => x.Nome == model.Nome))
                    return (new SistemaResponseDTO(), "Sistema já cadastrado.");

                var sistema = _mapper.Map<Sistema>(model);
                await _sistemaRepository.CreateAsync(sistema);

                return (_mapper.Map<SistemaResponseDTO>(sistema), string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SistemaResponseDTO> DeleteAsync(SistemaExclusaoModel model)
        {
            try
            {
                var sistema = await _sistemaRepository.GetByIdAsync(model.Id);

                if (sistema != null)
                {
                    await _sistemaRepository.DeleteAsync(sistema);
                }

                return _mapper.Map<SistemaResponseDTO>(model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<(SistemaResponseDTO dto, string mensagem)> UpdateAsync(SistemaEdicaoModel model)
        {
            try
            {
                var sistema = await _sistemaRepository.GetByIdAsync(model.Id);

                if (sistema == null)
                    return (new SistemaResponseDTO(), "Sistema não encontrado.");

                _mapper.Map(model, sistema);

                await _sistemaRepository.UpdateAsync(sistema);

                return (_mapper.Map<SistemaResponseDTO>(sistema), string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SistemaResponseDTO>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<List<SistemaResponseDTO>>(await _sistemaRepository.GetAllAsync());

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SistemaResponseDTO>> GetAllAsync(SistemaRequestDTO dto)
        {
            try
            {
                return _mapper.Map<List<SistemaResponseDTO>>(await _sistemaRepository.GetAllAsync(x => (string.IsNullOrEmpty(dto.Id) || x.Id == Guid.Parse(dto.Id)) &&
                                                                                                       (string.IsNullOrEmpty(dto.Nome) || x.Nome == dto.Nome)));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SistemaResponseDTO> GetByIdAsync(Guid id)
        {
            try
            {
                return _mapper.Map<SistemaResponseDTO>(await _sistemaRepository.GetByIdAsync(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}