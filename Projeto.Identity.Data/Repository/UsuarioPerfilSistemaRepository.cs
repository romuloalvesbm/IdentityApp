using Microsoft.EntityFrameworkCore;
using Projeto.Identity.Data.Context;
using Projeto.Identity.Domain.Contracts.Repositories;
using Projeto.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Data.Repository
{
    public class UsuarioPerfilSistemaRepository : BaseRepository<UsuarioPerfilSistema>, IUsuarioPerfilSistemaRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioPerfilSistemaRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<List<UsuarioPerfilSistema>> GetAllAsync()
        {
            return await _dataContext.UsuarioPerfilSistemas.Include(x => x.Usuario).Include(x => x.Perfil).ThenInclude(x => x.Sistema)
                                                                                   .Include(x => x.Perfil).ThenInclude(x => x.PerfilxPermissoes).ThenInclude(x => x.Permissao).ToListAsync();
        }

        public async Task<Guid?> ObterPerfilUsuario(Guid sistemaId, Guid UsuarioId)
        {
            return (await _dataContext.UsuarioPerfilSistemas.FirstOrDefaultAsync(x => x.SistemaId == sistemaId && x.UsuarioId == UsuarioId))?.PerfilId;
        }

        public async Task<UsuarioPerfilSistema?> ObterPermissaoUsuario(Guid sistemaId, Guid usuarioId)
        {
            return await _dataContext.UsuarioPerfilSistemas.Include(x => x.Usuario).Include(x => x.Perfil).ThenInclude(x => x.Sistema)
                                                                                   .Include(x => x.Perfil).ThenInclude(x => x.PerfilxPermissoes).ThenInclude(x => x.Permissao)
                                                                                  .FirstOrDefaultAsync(x => x.SistemaId == sistemaId && x.Usuario.Id == usuarioId);                                                                                  
        }

        public async Task<List<string>> ObterPermissoes(Guid sistemaId, Guid perfilId)
        {
            return await _dataContext.UsuarioPerfilSistemas.Include(x => x.Usuario).Include(x => x.Perfil).ThenInclude(x => x.PerfilxPermissoes).ThenInclude(x => x.Permissao)
                                                                                   .Where(x => x.Perfil.SistemaId == sistemaId && x.PerfilId == perfilId)
                                                                                   .Select(x => x.Perfil).SelectMany(x => x.PerfilxPermissoes).Select(x => x.Permissao.ChaveAutorizacao)
                                                                                   .ToListAsync();
        }
    }
}
