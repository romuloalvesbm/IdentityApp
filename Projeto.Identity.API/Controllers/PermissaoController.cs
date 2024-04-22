using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting.Authorization;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Permissao;

namespace Projeto.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissaoController : ControllerBase
    {
        private readonly IPermissaoDomainService _PermissaoDomainService;

        public PermissaoController(IPermissaoDomainService PermissaoService)
        {
            _PermissaoDomainService = PermissaoService;
        }

        [ClaimsAuthorize("CustomizePermission", "CadastrarPermissao")]
        [HttpPost]
        public async Task<IActionResult> Post(PermissaoCadastroModel model)
        {
            try
            {
                var result = await _PermissaoDomainService.CreateAsync(model);

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

        [ClaimsAuthorize("CustomizePermission", "EditarPermissao")]
        [HttpPut]
        public async Task<IActionResult> Put(PermissaoEdicaoModel model)
        {
            try
            {
                var result = await _PermissaoDomainService.UpdateAsync(model);

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

        [ClaimsAuthorize("CustomizePermission", "ExcluirPermissao")]
        [HttpDelete]
        public async Task<IActionResult> Delete(PermissaoExclusaoModel model)
        {
            try
            {
                var result = await _PermissaoDomainService.DeleteAsync(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [ClaimsAuthorize("CustomizePermission", "ListarPermissao")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _PermissaoDomainService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ListarFiltroPermissao")]
        [HttpGet("GetAllFilter")]
        public async Task<IActionResult> GetAll([FromQuery] PermissaoRequestDTO dto)
        {
            try
            {
                return Ok(await _PermissaoDomainService.GetAllAsync(dto));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ObterPorIdPermissao")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _PermissaoDomainService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
