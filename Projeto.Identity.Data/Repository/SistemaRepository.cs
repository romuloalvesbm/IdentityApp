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
    public class SistemaRepository : BaseRepository<Sistema>, ISistemaRepository
    {
        private readonly DataContext dataContext;

        public SistemaRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public override async Task<List<Sistema>> GetAllAsync()
        {
            return await dataContext.Sistemas.Include(x => x.Perfils).ThenInclude(x => x.PerfilxPermissoes).ThenInclude(x => x.Permissao).ToListAsync();
        }

        public override async Task<Sistema?> GetByIdAsync(Guid id)
        {
            return await dataContext.Sistemas.Include(x => x.Perfils).ThenInclude(x => x.PerfilxPermissoes).ThenInclude(x => x.Permissao).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

