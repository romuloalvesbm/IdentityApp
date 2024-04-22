using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class PermissaoResponseDTO
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public string? ChaveAutorizacao { get; set; }
    }
}
