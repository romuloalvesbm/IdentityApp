using Projeto.Identity.API.Extensions;
using Projeto.Identity.Domain.Extensions;
using Projeto.Identity.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerDoc();
app.UseCorsConfig();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

