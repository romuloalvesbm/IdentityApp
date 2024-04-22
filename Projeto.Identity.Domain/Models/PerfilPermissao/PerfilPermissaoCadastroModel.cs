using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Models.PerfilPermissao
{
    public class PerfilPermissaoCadastroModel
    {
        [Required(ErrorMessage = "Informe o id do perfil.")]
        public Guid PerfilId { get; set; }

        [Required(ErrorMessage = "Informe o id do sistema.")]
        public Guid SistemaId { get; set; }

        [Required(ErrorMessage = "Informe o id da permissao.")]
        public Guid PermissaoId { get; set; }
    }
}
