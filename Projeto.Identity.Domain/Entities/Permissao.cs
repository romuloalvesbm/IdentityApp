using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Entities
{
    public class Permissao
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string ChaveAutorizacao { get; set; }

        #region Relacionamentos
        public List<PerfilPermissao> PerfilxPermissoes { get; set; }
        #endregion
    }
}
