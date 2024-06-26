﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto.Identity.API.Models;
using Projeto.Identity.API.Services;
using Projeto.Identity.Domain.Contracts.Services;

namespace Projeto.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IUsuarioPerfilSistemaDomainService _usuarioPerfilSistemaDomainService;
        private readonly JwtTokenService _jwtTokenService;

        public LoginController(IUsuarioDomainService usuarioDomainService, JwtTokenService jwtTokenService, IUsuarioPerfilSistemaDomainService usuarioPerfilSistemaDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
            _jwtTokenService = jwtTokenService;
            _usuarioPerfilSistemaDomainService = usuarioPerfilSistemaDomainService;
        }

        private string msgAcessoNegado => "Acesso negado. Usuário inválido.";

        [HttpPost]
        [Route("autenticar")] //ENDPOINT: api/usuarios/autenticar
        public async Task<IActionResult> Autenticar(AutenticarUsuarioRequestModel model)
        {
            #region Buscar o usuário através do email

            var usuario = await _usuarioDomainService.GetByEmailAsync(model.Email);
            if (usuario == null)
                return StatusCode(401, new { Message = msgAcessoNegado });

            #endregion

            #region Verificar se a senha está correta

            var isPasswordValid = _usuarioDomainService.VerifyPassword(usuario.Senha, model.Senha);
            if (!isPasswordValid)
                return StatusCode(401, new { Message = msgAcessoNegado });

            #endregion

            #region Retornar os dados do usuário autenticado

            #region Verificar se usuário possui perfil no sistema

            var perfilId = await _usuarioPerfilSistemaDomainService.ObterPerfilUsuario(model.SistemaId, usuario.Id);
            if (perfilId == null)
                return StatusCode(401, new { Message = msgAcessoNegado });

            #endregion

            var response = new AutenticarUsuarioResponseModel
            {
                UsuarioId = usuario.Id.ToString(),
                Nome = usuario.Nome,
                Email = usuario.Email,
                AccessToken = _jwtTokenService.CreateToken(new Domain.Dtos.UsuarioPermissaoDTO 
                                                          {
                                                            Id = usuario.Id,
                                                            Nome = usuario.Nome,
                                                            Email = usuario.Email,
                                                            Permissoes = await _usuarioPerfilSistemaDomainService.ObterPermissoes(model.SistemaId, (Guid)perfilId)
                                                           }),
                DataHoraAcesso = DateTime.Now
            };

            return Ok(response);

            #endregion
        }
    }
}
