﻿using Projeto.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Contracts.Repositories
{
    public interface IUsuarioPerfilSistemaRepository : IBaseRepository<UsuarioPerfilSistema>
    {
        Task<List<string>> ObterPermissoes(Guid sistemaId, Guid perfilId, Guid usuarioId);
        Task<Guid?> ObterPerfilUsuario(Guid sistemaId, Guid UsuarioId);
        Task<UsuarioPerfilSistema?> ObterPermissaoUsuario(Guid sistemaId, Guid usuarioId);
    }
}
