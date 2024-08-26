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
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<List<Usuario>> GetAllAsync()
        {
            return await _dataContext.Usuarios.Include(x => x.UsuarioxPerfilxSistemas)
                                              .ThenInclude(x => x.Perfil).ThenInclude(x => x.Sistema)
                                              .Include(x => x.UsuarioxPerfilxSistemas)
                                              .ThenInclude(x => x.Perfil).ThenInclude(x => x.PerfilxPermissoes).ThenInclude(x => x.Permissao).ToListAsync();
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _dataContext.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }

        public override async Task<Usuario?> GetByIdAsync(Guid id)
        {
            return await _dataContext.Usuarios.Include(x => x.UsuarioxPerfilxSistemas)
                                             .ThenInclude(x => x.Perfil).ThenInclude(x => x.Sistema)
                                             .Include(x => x.UsuarioxPerfilxSistemas)
                                             .ThenInclude(x => x.Perfil).ThenInclude(x => x.PerfilxPermissoes).ThenInclude(x => x.Permissao).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
