using System.ComponentModel.DataAnnotations;

namespace Projeto.Identity.API.Models
{
    public class AutenticarUsuarioRequestModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o id do sistema.")]
        public Guid SistemaId { get; set; }
       
    }
}
