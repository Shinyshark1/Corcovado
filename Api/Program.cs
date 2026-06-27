using Api;
using Api.Services.DatabaseFile;
using DAL;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var corcovadoConnectionString = builder.Configuration["ConnectionStrings:CorcovadoDatabase"];
if(string.IsNullOrWhiteSpace(corcovadoConnectionString))
{
    throw new InvalidOperationException("ConnectionStrings:CorcovadoDatabase is required");
}

builder.Services.AddCorcovadoDataLayer(corcovadoConnectionString);

builder.Services.InjectRepositories();
builder.Services.InjectServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Services.ApplyDatabaseMigrations();

await app.RunAsync();
