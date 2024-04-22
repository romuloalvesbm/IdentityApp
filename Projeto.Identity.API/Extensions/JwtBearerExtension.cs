using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Projeto.Identity.API.Services;
using Projeto.Identity.API.Settings;
using System.Text;

namespace Projeto.Identity.API.Extensions
{
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearer
                    (this IServiceCollection services, IConfiguration configuration)
        {
            //configurando os parametros do /appsettings
            var jwtTokenSettings = new JwtTokenSettings();
            new ConfigureFromConfigurationOptions<JwtTokenSettings>
                (configuration.GetSection("JwtTokenSettings"))
                .Configure(jwtTokenSettings);

            var key = Encoding.ASCII.GetBytes(jwtTokenSettings.SecurityKey);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // Defina como true em produção
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtTokenSettings.Issuer,
                    ValidAudience = jwtTokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });

            services.AddSingleton(jwtTokenSettings);
            services.AddTransient<JwtTokenService>();

            return services;
        }
    }
}

