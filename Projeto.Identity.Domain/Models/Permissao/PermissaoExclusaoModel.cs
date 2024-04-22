using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Models.Permissao
{
    public class PermissaoExclusaoModel
    {
        [Required(ErrorMessage = "Informe o id da permissão.")]
        public Guid Id { get; set; }
    }
}
