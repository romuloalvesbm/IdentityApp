using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class PerfilPermissaoResponseDTO
    {
        public Guid Id { get; set; }
        public Guid SistemaId { get; set; }
        public string Sistema { get; set; }
        public Guid PerfilId { get; set; }
        public string Perfil { get; set; }
        public Guid PermissaoId { get; set; }
        public string Permissao { get; set; }
    }
}
