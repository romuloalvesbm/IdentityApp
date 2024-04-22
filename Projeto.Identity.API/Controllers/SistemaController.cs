using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting.Authorization;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Sistema;

namespace Projeto.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        private readonly ISistemaDomainService _sistemaDomainService;

        public SistemaController(ISistemaDomainService sistemaService)
        {
            _sistemaDomainService = sistemaService;
        }

        [ClaimsAuthorize("CustomizePermission", "CadastrarSistema")]
        [HttpPost]
        public async Task<IActionResult> Post(SistemaCadastroModel model)
        {
            try
            {
                var result = await _sistemaDomainService.CreateAsync(model);

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

        [ClaimsAuthorize("CustomizePermission", "EditarSistema")]
        [HttpPut]
        public async Task<IActionResult> Put(SistemaEdicaoModel model)
        {
            try
            {
                var result = await _sistemaDomainService.UpdateAsync(model);

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

        [ClaimsAuthorize("CustomizePermission", "ExcluirSistema")]
        [HttpDelete]
        public async Task<IActionResult> Delete(SistemaExclusaoModel model)
        {
            try
            {
                var result = await _sistemaDomainService.DeleteAsync(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ListarSistema")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _sistemaDomainService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ListarFiltroSistema")]
        [HttpGet("GetAllFilter")]
        public async Task<IActionResult> GetAll([FromQuery] SistemaRequestDTO dto)
        {
            try
            {
                return Ok(await _sistemaDomainService.GetAllAsync(dto));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //[HttpPost("GetAllFilter2")]
        //public async Task<IActionResult> GetAll2([FromBody]SistemaRequestDTO dto)
        //{
        //    //Mesmo exemplo de cima apenas http verb diferente
        //    try
        //    {
        //        return Ok(await _sistemaService.GetAllAsync(dto));
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}       

        [ClaimsAuthorize("CustomizePermission", "ObterPorIdSistema")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _sistemaDomainService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

