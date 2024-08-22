using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Projeto.Identity.API.Extensions
{
    public static class SwaggerDocExtension
    {
        /// <summary>
        /// Método de extensão para configurar as preferências do Swagger
        /// </summary>
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                options =>
                {
                    //Informações exibidas na documentação do Swagger
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Identity User API - Gerenciamento de Acesso Multissistema",
                        Description = "API para autenticação e controle de usuários.",
                        Version = "1.0",
                        Contact = new OpenApiContact
                        {
                            Name = "Rômulo Alves",
                            Email = "romuloalves.br@gmail.com.br",
                            Url = new Uri("https://www.linkedin.com/in/rômulo-alves-a4144113b/")
                        }
                    });

                    //Configurações para testes de autenticação
                    options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Entre com o TOKEN JWT",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });

                    //Informações adicionais para testes de autenticação
                    options.AddSecurityRequirement
                    (new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[]{ }
                        }
                    });

                    options.AddSecurityDefinition("ApiVersion", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Name = "X-ApiVersion",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                        Description = "Cabeçalho para especificar a versão da API"
                    });

                    options.AddSecurityDefinition("ClientId", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Name = "client_id",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                        Description = "Cabeçalho para especificar o ID do cliente"
                    });

                    options.AddSecurityDefinition("ClientSecret", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Name = "client_secret",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                        Description = "Cabeçalho para especificar o segredo do cliente"
                    });

                    options.OperationFilter<CustomHeaderSwaggerAttribute>();
                });

            return services;
        }

        /// <summary>
        /// Método para configurar a execução do Swagger
        /// </summary>
        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuariosApp");
            });

            return app;
        }

        public class CustomHeaderSwaggerAttribute : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "X-ApiVersion",
                    In = ParameterLocation.Header,
                    Required = true, // Defina como true se o cabeçalho for obrigatório
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "client_id",
                    In = ParameterLocation.Header,
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "client_secret",
                    In = ParameterLocation.Header,
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });
            }
        }
    }
}

