using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Models.Perfil;

namespace Projeto.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilDomainService _perfilService;

        public PerfilController(IPerfilDomainService perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PerfilCadastroModel model)
        {
            try
            {
                var result = await _perfilService.CreateAsync(model);

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
        public async Task<IActionResult> Put(PerfilEdicaoModel model)
        {
            try
            {
                var result = await _perfilService.UpdateAsync(model);

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
        public async Task<IActionResult> Delete(PerfilExclusaoModel model)
        {
            try
            {
                var result = await _perfilService.DeleteAsync(model);

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
                return Ok(await _perfilService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetAllFilter")]
        public async Task<IActionResult> GetAll([FromQuery] PerfilRequestDTO dto)
        {
            try
            {
                return Ok(await _perfilService.GetAllAsync(dto));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _perfilService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}