using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Projeto.Identity.Domain.Contracts.Repositories;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using Projeto.Identity.Domain.Models.Sistema;
using Projeto.Identity.Domain.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly PasswordHasher<string> _passwordHasher;

        public UsuarioDomainService(IMapper mapper, IUsuarioRepository usuarioRepository, PasswordHasher<string> passwordHasher)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<(UsuarioResponseDTO dto, string mensagem)> CreateAsync(UsuarioCadastroModel model)
        {
            try
            {
                if (await _usuarioRepository.AnyAsync(x => x.Email == model.Email))
                    return (new UsuarioResponseDTO(), "Email já cadastrado.");               

                var usuario = _mapper.Map<Usuario>(model);
                await _usuarioRepository.CreateAsync(usuario);

                return (_mapper.Map<UsuarioResponseDTO>(usuario), string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UsuarioResponseDTO> DeleteAsync(UsuarioExclusaoModel model)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByIdAsync(model.Id);

                if (usuario != null)
                {
                    await _usuarioRepository.DeleteAsync(usuario);
                }

                return _mapper.Map<UsuarioResponseDTO>(model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<(UsuarioResponseDTO dto, string mensagem)> UpdateAsync(UsuarioEdicaoModel model)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByIdAsync(model.Id);

                if (usuario == null)
                    return (new UsuarioResponseDTO(), "Usuário não encontrado.");

                _mapper.Map(model, usuario);

                await _usuarioRepository.UpdateAsync(usuario);

                return (_mapper.Map<UsuarioResponseDTO>(usuario), string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UsuarioResponseDTO>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<List<UsuarioResponseDTO>>(await _usuarioRepository.GetAllAsync());

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UsuarioResponseDTO>> GetAllAsync(UsuarioRequestDTO dto)
        {
            try
            {
                return _mapper.Map<List<UsuarioResponseDTO>>(await _usuarioRepository.GetAllAsync(x => (string.IsNullOrEmpty(dto.Id) || x.Id == Guid.Parse(dto.Id)) &&
                                                                                                       (string.IsNullOrEmpty(dto.Nome) || x.Nome == dto.Nome) &&
                                                                                                       (string.IsNullOrEmpty(dto.Email) || x.Nome == dto.Email)));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UsuarioResponseDTO> GetByIdAsync(Guid id)
        {
            try
            {
                return _mapper.Map<UsuarioResponseDTO>(await _usuarioRepository.GetByIdAsync(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UsuarioResponseDTO> GetByEmailAsync(string email)
        {
            try
            {
                return _mapper.Map<UsuarioResponseDTO>(await _usuarioRepository.GetByEmailAsync(email));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            try
            {
                var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
                return result == PasswordVerificationResult.Success;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
