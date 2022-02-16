using Base.API.Config;
using Base.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.ResolveDependencyInjection();

var app = builder.Build();

app.UseApiConfiguration(builder.Environment);
app.UseSwaggerConfiguration();

app.RunMigration();

app.Run();