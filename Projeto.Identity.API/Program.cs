using Projeto.Identity.API.Extensions;
using Projeto.Identity.Domain.Extensions;
using Projeto.Identity.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerDoc();
app.UseAuthorization();
app.MapControllers();

app.Run();

