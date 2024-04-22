using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Identity.Domain.Contracts.Services;
using Projeto.Identity.Domain.Mappings;
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
            // Configurando dependência PasswordHasher
            services.AddSingleton<PasswordHasher<string>>();

            //configurando o AutoMapper
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton(provider =>
            {
                var passwordHasher = provider.GetRequiredService<PasswordHasher<string>>();

                return new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile(passwordHasher));
                }).CreateMapper();
            });

            //registrando as interfaces/classes de serviço da aplicação
            services.AddTransient<ISistemaDomainService, SistemaDomainService>();
            services.AddTransient<IPerfilDomainService, PerfilDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IPermissaoDomainService, PermissaoDomainService>();
            services.AddTransient<IPerfilPermissaoDomainService, PerfilPermissaoDomainService>();
            services.AddTransient<IUsuarioPerfilSistemaDomainService, UsuarioPerfilSistemaDomainService>();

            return services;
        }
    }
}
