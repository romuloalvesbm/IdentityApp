using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Models.Permissao
{
    public class PermissaoEdicaoModel
    {
        [Required(ErrorMessage = "Informe o id da permissão.")]
        public Guid Id { get; set; }

        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a permissão do perfil.")]
        public string Descricao { get; set; }

        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a chave de autorização.")]
        public string ChaveAutorizacao { get; set; }
    }
}
