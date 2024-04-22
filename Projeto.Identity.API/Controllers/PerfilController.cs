using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting.Authorization;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Perfil;

namespace Projeto.Identity.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilDomainService _perfilDomainService;

        public PerfilController(IPerfilDomainService perfilService)
        {
            _perfilDomainService = perfilService;
        }

        [ClaimsAuthorize("CustomizePermission", "CadastrarPerfil")]
        [HttpPost]
        public async Task<IActionResult> Post(PerfilCadastroModel model)
        {
            try
            {
                var result = await _perfilDomainService.CreateAsync(model);

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

        [ClaimsAuthorize("CustomizePermission", "EditarPerfil")]
        [HttpPut]
        public async Task<IActionResult> Put(PerfilEdicaoModel model)
        {
            try
            {
                var result = await _perfilDomainService.UpdateAsync(model);

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

        [ClaimsAuthorize("CustomizePermission", "ExcluirPerfil")]
        [HttpDelete]
        public async Task<IActionResult> Delete(PerfilExclusaoModel model)
        {
            try
            {
                var result = await _perfilDomainService.DeleteAsync(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ListarPerfil")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _perfilDomainService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ListarFiltroPerfil")]
        [HttpGet("GetAllFilter")]
        public async Task<IActionResult> GetAll([FromQuery] PerfilRequestDTO dto)
        {
            try
            {
                return Ok(await _perfilDomainService.GetAllAsync(dto));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ObterPorIdPerfil")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _perfilDomainService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}