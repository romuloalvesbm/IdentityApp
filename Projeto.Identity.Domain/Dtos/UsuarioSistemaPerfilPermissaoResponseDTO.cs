using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class UsuarioSistemaPerfilPermissaoResponseDTO
    {
        public Guid IdUsuarioPerfilSistema { get; set; }
        public UsuarioResponseDTO? UsuarioResponseDTO { get; set; }
    }
}
