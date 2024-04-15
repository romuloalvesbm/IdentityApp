using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Entities
{
    public class UsuarioPerfilSistema
    {
        public Guid IdUsuarioPerfilSistema { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid PerfilId { get; set; } //Chave estrangeira composto table Perfil
        public Guid SistemaId { get; set; } //Chave estrangeira composto table Perfil      

        #region Relacionamentos
        public Perfil Perfil { get; set; }
        public Usuario Usuario { get; set; }
        #endregion
    }
}
