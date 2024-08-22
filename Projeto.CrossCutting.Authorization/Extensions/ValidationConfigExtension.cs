using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.CrossCutting.Authorization.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.CrossCutting.Authorization.Extensions
{
    public static class ValidationConfigExtension
    {
        public static IServiceCollection AddValidationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurar a leitura das configurações do appsettings.json
            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

            services.AddScoped<RequestAuthorization>();

            return services;
        }
    }
}
