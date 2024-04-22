using Projeto.Identity.Domain.Models.Usuario;
using Projeto.Identity.Domain.Models.UsuarioPerfilSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class UsuarioPerfilSistemaResponseDTO
    {
        public Guid IdUsuarioPerfilSistema { get; set; }
        public Guid UsuarioId { get; set; }
        public string Usuario { get; set; }
        public Guid SistemaId { get; set; }
        public string Sistema { get; set; }
        public Guid PerfilId { get; set; }
        public string Perfil { get; set; }       
    }
}
