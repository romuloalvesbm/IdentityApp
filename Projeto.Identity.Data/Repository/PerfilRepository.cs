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
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        private readonly DataContext _dataContext;

        public PerfilRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<List<Perfil>> GetAllAsync()
        {
            return await _dataContext.Perfils.Include(x => x.Sistema).Include(x => x.PerfilxPermissoes).ThenInclude(x => x.Permissao).ToListAsync();
        }
    }
}

