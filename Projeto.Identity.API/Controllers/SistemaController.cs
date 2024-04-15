using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Sistema;

namespace Projeto.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        private readonly ISistemaDomainService _sistemaService;

        public SistemaController(ISistemaDomainService sistemaService)
        {
            _sistemaService = sistemaService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SistemaCadastroModel model)
        {
            try
            {
                var result = await _sistemaService.CreateAsync(model);

                if (result.IsFinalizado)
                    return Ok(result);
                else
                    return StatusCode(400, new { result.Mensagem_Excecao });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(SistemaEdicaoModel model)
        {
            try
            {
                var result = await _sistemaService.UpdateAsync(model);

                if (result.IsFinalizado)
                    return Ok(result);
                else
                    return StatusCode(400, new { result.Mensagem_Excecao });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(SistemaExclusaoModel model)
        {
            try
            {
                var result = await _sistemaService.DeleteAsync(model);

                if (result.IsFinalizado)
                    return Ok(result);
                else
                    return StatusCode(400, new { result.Mensagem_Excecao });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _sistemaService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetAllFilter")]
        public async Task<IActionResult> GetAll([FromQuery] SistemaRequestDTO dto)
        {
            try
            {
                return Ok(await _sistemaService.GetAllAsync(dto));
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _sistemaService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

