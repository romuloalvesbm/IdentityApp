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
    public class PerfilPermissaoRepository : BaseRepository<PerfilPermissao>, IPerfilPermissaoRepository
    {
        private readonly DataContext _dataContext;

        public PerfilPermissaoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<List<PerfilPermissao>> GetAllAsync()
        {
            return await _dataContext.PerfilPermissoes.Include(x => x.Perfil).ThenInclude(x => x.Sistema).Include(x => x.Permissao).ToListAsync();
        }        
    }
}
