using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting.Authorization;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Models.PerfilPermissao;
using Projeto.Identity.Domain.Models.Sistema;
using Projeto.Identity.Domain.Services;

namespace Projeto.Identity.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilPermissaoController : ControllerBase
    {
        private readonly IPerfilPermissaoDomainService _perfilPermissaoDomainService;

        public PerfilPermissaoController(IPerfilPermissaoDomainService perfilPermissaoDomainService)
        {
            _perfilPermissaoDomainService = perfilPermissaoDomainService;
        }

        [ClaimsAuthorize("CustomizePermission", "CadastrarPerfilPermissao")]
        [HttpPost]
        public async Task<IActionResult> Post(PerfilPermissaoCadastroModel model)
        {
            try
            {
                var result = await _perfilPermissaoDomainService.CreateAsync(model);

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

        [ClaimsAuthorize("CustomizePermission", "ExcluirPerfilPermissao")]
        [HttpDelete]
        public async Task<IActionResult> Delete(PerfilPermissaoExclusaoModel model)
        {
            try
            {
                var result = await _perfilPermissaoDomainService.DeleteAsync(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ClaimsAuthorize("CustomizePermission", "ListarPerfilPermissao")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _perfilPermissaoDomainService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
