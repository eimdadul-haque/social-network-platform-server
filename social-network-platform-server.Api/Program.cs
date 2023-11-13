using Microsoft.EntityFrameworkCore;
using Serilog;
using social_network_platform_server.Api.middlewares;
using social_network_platform_server.Application.Contracts.Posts.Interfaces;
using social_network_platform_server.Application.Contracts.Repository.Interfaces;
using social_network_platform_server.Application.Posts;
using social_network_platform_server.Application.Repositorys;
using social_network_platform_server.Infrastructure.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));



// Add services to the container.

builder.Services.AddControllers();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("log.txt")
    .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app is not null)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
