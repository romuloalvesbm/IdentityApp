using Microsoft.Extensions.DependencyInjection;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Extensions
{
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //configurando o AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //registrando as interfaces/classes de serviço da aplicação
            services.AddTransient<ISistemaDomainService, SistemaDomainService>();
            services.AddTransient<IPerfilDomainService, PerfilDomainService>();

            return services;
        }
    }
}
