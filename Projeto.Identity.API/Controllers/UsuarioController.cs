using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting.Authorization;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Perfil;
using Projeto.Identity.Domain.Models.Sistema;
using Projeto.Identity.Domain.Models.Usuario;
using Projeto.Identity.Domain.Services;

namespace Projeto.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioDomainService _usuarioDomainService;

        public UsuarioController(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        [ClaimsAuthorize("CustomizePermission", "CadastrarUsuario")]
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioCadastroModel model)
        {
            try
            {
                var result = await _usuarioDomainService.CreateAsync(model);

                if(string.IsNullOrEmpty(result.mensagem))
                    return Ok(result.dto);
                else
                    return StatusCode(400, new { result.mensagem });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "EditarUsuario")]
        [HttpPut]
        public async Task<IActionResult> Put(UsuarioEdicaoModel model)
        {
            try
            {
                var result = await _usuarioDomainService.UpdateAsync(model);

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

        [ClaimsAuthorize("CustomizePermission", "ExcluirUsuario")]
        [HttpDelete]
        public async Task<IActionResult> Delete(UsuarioExclusaoModel model)
        {
            try
            {
                var result = await _usuarioDomainService.DeleteAsync(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ListarUsuario")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _usuarioDomainService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ListarFiltroUsuario")]
        [HttpGet("GetAllFilter")]
        public async Task<IActionResult> GetAll([FromQuery] UsuarioRequestDTO dto)
        {
            try
            {
                return Ok(await _usuarioDomainService.GetAllAsync(dto));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ObterPorIdUsuario")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _usuarioDomainService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
