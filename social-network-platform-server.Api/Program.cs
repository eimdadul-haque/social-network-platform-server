using social_network_platform_server.Application.Contracts.Repository.Interfaces;
using social_network_platform_server.Application.Repositorys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));  

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
