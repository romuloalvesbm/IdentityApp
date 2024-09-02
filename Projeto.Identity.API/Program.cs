using Projeto.Identity.API.Extensions;
using Projeto.Identity.Domain.Extensions;
using Projeto.Identity.Data.Extensions;
using Projeto.CrossCutting.Authorization.Extensions;

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IgnoreNullValues = true;
}); 
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddCorsConfig();
builder.Services.AddValidationConfig(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerDoc();
app.UseCorsConfig();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

