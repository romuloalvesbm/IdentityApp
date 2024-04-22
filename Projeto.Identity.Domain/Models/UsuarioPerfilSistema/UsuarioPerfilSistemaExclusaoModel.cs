using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Models.UsuarioPerfilSistema
{
    public class UsuarioPerfilSistemaExclusaoModel
    {
        [Required(ErrorMessage = "Informe o id.")]
        public Guid IdUsuarioPerfilSistema { get; set; }        
    }
}
