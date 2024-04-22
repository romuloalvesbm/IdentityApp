using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Models.PerfilPermissao
{
    public class PerfilPermissaoExclusaoModel
    {
        [Required(ErrorMessage = "Informe o id do sistema.")]
        public Guid Id { get; set; }        
    }
}
