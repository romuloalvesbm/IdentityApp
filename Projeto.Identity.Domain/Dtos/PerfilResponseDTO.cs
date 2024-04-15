using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class PerfilResponseDTO : MensagemDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid SistemaId { get; set; }
        public string Sistema { get; set; }
    }
}

