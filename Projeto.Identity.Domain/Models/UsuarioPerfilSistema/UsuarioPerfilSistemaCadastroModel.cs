using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Models.UsuarioPerfilSistema
{
    public class UsuarioPerfilSistemaCadastroModel
    {        

        [Required(ErrorMessage = "Informe o id do perfil.")]
        public Guid PerfilId { get; set; }

        [Required(ErrorMessage = "Informe o id do sistema.")]
        public Guid SistemaId { get; set; }       

        [Required(ErrorMessage = "Informe o id do usuário.")]
        public Guid UsuarioId { get; set; }
    }
}
