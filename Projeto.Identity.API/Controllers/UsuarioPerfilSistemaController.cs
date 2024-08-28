using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting.Authorization;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Models.PerfilPermissao;
using Projeto.Identity.Domain.Models.UsuarioPerfilSistema;
using Projeto.Identity.Domain.Services;

namespace Projeto.Identity.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPerfilSistemaController : ControllerBase
    {
        public readonly IUsuarioPerfilSistemaDomainService _usuarioPerfilSistemaDomainService;

        public UsuarioPerfilSistemaController(IUsuarioPerfilSistemaDomainService usuarioPerfilSistemaDomainService)
        {
            _usuarioPerfilSistemaDomainService = usuarioPerfilSistemaDomainService;
        }

        [ClaimsAuthorize("CustomizePermission", "CadastrarUsuarioPerfilSistema")]
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioPerfilSistemaCadastroModel model)
        {
            try
            {
                var result = await _usuarioPerfilSistemaDomainService.CreateAsync(model);

                if (string.IsNullOrEmpty(result.mensagem))
                    return Ok(result.dto);
                else
                    return StatusCode(400, new { result.mensagem });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ExcluirUsuarioPerfilSistema")]
        [HttpDelete]
        public async Task<IActionResult> Delete(UsuarioPerfilSistemaExclusaoModel model)
        {
            try
            {
                var result = await _usuarioPerfilSistemaDomainService.DeleteAsync(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ListarUsuarioPerfilSistema")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _usuarioPerfilSistemaDomainService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ObterPermissaoUsuarioNoSistema")]
        [HttpGet("ObterPermissaoUsuario")]
        public async Task<IActionResult> ObterPermissaoUsuario([FromQuery] Guid sistemaId, Guid usuarioId)
        {
            try
            {
                return Ok(await _usuarioPerfilSistemaDomainService.ObterPermissaoUsuario(sistemaId, usuarioId));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
