using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class UsuarioRequestDTO
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        //public string Senha { get; set; }      
    }
}
