using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Models.Sistema
{
    public class SistemaEdicaoModel
    {
        [Required(ErrorMessage = "Informe o id do sistema.")]
        public Guid Id { get; set; }


        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o nome do sistema.")]
        public string Nome { get; set; }

        [MaxLength(30, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a versão do sistema.")]
        public string Versao { get; set; }
    }
}
