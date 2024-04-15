using AutoMapper;
using Projeto.Identity.Domain.Contracts.Repositories;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using Projeto.Identity.Domain.Models.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Services
{
    public class PerfilDomainService : IPerfilDomainService
    {
        private readonly IMapper _mapper;
        private readonly IPerfilRepository _perfilRepository;
        private readonly ISistemaRepository _sistemaRepository;

        public PerfilDomainService(IMapper mapper, IPerfilRepository perfilRepository, ISistemaRepository sistemaRepository)
        {
            _mapper = mapper;
            _perfilRepository = perfilRepository;
            _sistemaRepository = sistemaRepository;
        }

        public async Task<PerfilResponseDTO> CreateAsync(PerfilCadastroModel model)
        {
            try
            {
                if (!await _sistemaRepository.AnyAsync(x => x.Id == model.SistemaId))
                    return new PerfilResponseDTO { Mensagem_Excecao = "Sistema não encontrado." };

                if (await _perfilRepository.AnyAsync(x => x.Nome == model.Nome))
                    return new PerfilResponseDTO { Mensagem_Excecao = "Perfil já cadastrado." };

                var perfil = _mapper.Map<Perfil>(model);
                await _perfilRepository.CreateAsync(perfil);

                return _mapper.Map<PerfilResponseDTO>(perfil);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PerfilResponseDTO> UpdateAsync(PerfilEdicaoModel model)
        {
            try
            {
                var perfil = await _perfilRepository.GetByIdAsync(model.Id);
                if (perfil != null)
                    return new PerfilResponseDTO { Mensagem_Excecao = "Perfil não encontrado." };

                var sistema = await _sistemaRepository.GetByIdAsync(model.Id);
                if (sistema != null)
                    return new PerfilResponseDTO { Mensagem_Excecao = "Sistema não encontrado." };

                await _perfilRepository.UpdateAsync(_mapper.Map<Perfil>(perfil));

                return _mapper.Map<PerfilResponseDTO>(perfil);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PerfilResponseDTO> DeleteAsync(PerfilExclusaoModel model)
        {
            try
            {
                var perfil = await _perfilRepository.GetByIdAsync(model.Id);

                if (perfil != null)
                {
                    await _perfilRepository.DeleteAsync(perfil);
                }

                return _mapper.Map<PerfilResponseDTO>(perfil);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PerfilResponseDTO>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<List<PerfilResponseDTO>>(await _perfilRepository.GetAllAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PerfilResponseDTO>> GetAllAsync(PerfilRequestDTO dto)
        {
            try
            {
                return _mapper.Map<List<PerfilResponseDTO>>(await _perfilRepository.GetAllAsync(x => (string.IsNullOrEmpty(dto.Id) || x.Id == Guid.Parse(dto.Id)) &&
                                                                                                     (string.IsNullOrEmpty(dto.SistemaId) || x.SistemaId == Guid.Parse(dto.SistemaId)) &&
                                                                                                     (string.IsNullOrEmpty(dto.Nome) || x.Nome.StartsWith(dto.Nome))));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PerfilResponseDTO> GetByIdAsync(Guid id)
        {
            try
            {
                return _mapper.Map<PerfilResponseDTO>(await _perfilRepository.GetByIdAsync(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
