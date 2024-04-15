using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class MensagemDTO
    {
        public string Mensagem_Excecao { get; set; }
        public bool IsFinalizado => string.IsNullOrEmpty(Mensagem_Excecao);
    }
}
