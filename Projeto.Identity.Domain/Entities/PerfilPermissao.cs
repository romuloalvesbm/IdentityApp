using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Entities
{
    public class PerfilPermissao
    {
        public Guid IdPerfilPermissao { get; set; }
        public Guid PerfilId { get; set; } //Chave estrangeira composta table Perfil
        public Guid SistemaId { get; set; } //Chave estrangeira composta table Perfil
        public Guid PermissaoId { get; set; }

        #region Relacionamentos
        public Perfil Perfil { get; set; }
        public Permissao Permissao { get; set; }
        #endregion
    }
}
