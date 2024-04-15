using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Entities
{
    public class Sistema
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Versao { get; set; }

        #region Relacionamentos
        public List<Perfil> Perfils { get; set; }

        #endregion
    }
}
