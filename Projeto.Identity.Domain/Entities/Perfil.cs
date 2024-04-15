using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Entities
{
    public class Perfil
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid SistemaId { get; set; }

        #region Relacionamentos
        public Sistema Sistema { get; set; }
        public List<PerfilPermissao> PerfilxPermissoes { get; set; }
        public List<UsuarioPerfilSistema> UsuarioxPerfilxSistemas { get; set; }
        #endregion
    }
}
