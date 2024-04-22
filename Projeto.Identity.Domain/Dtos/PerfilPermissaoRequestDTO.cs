using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class PerfilPermissaoRequestDTO
    {
        public string? IdPerfilPermissao { get; set; }
        public string? PerfilId { get; set; } 
        public string? SistemaId { get; set; } 
        public string? PermissaoId { get; set; }
    }
}
