using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Identity.Data.Context;
using Projeto.Identity.Data.Repository;
using Projeto.Identity.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Data.Extensions
{
    public static class DataContextExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            //injeção de dependência do DataContext
            services.AddDbContext<DataContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("BDIdentityUser")));

            //injeção de dependência do Repository
            services.AddTransient<IPerfilPermissaoRepository, PerfilPermissaoRepository>();
            services.AddTransient<IPerfilRepository, PerfilRepository>();
            services.AddTransient<IPermissaoRepository, PermissaoRepository>();
            services.AddTransient<ISistemaRepository, SistemaRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioPerfilSistemaRepository, UsuarioPerfilSistemaRepository>();

            return services;
        }

    }
}

