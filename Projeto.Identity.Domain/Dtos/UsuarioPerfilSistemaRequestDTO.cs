using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class UsuarioPerfilSistemaRequestDTO
    {
        public string? IdUsuarioPerfilSistema { get; set; }
        public string? UsuarioId { get; set; }
        public string? PerfilId { get; set; } 
        public string? SistemaId { get; set; } 
    }
}
