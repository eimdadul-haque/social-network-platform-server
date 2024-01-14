using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using social_network_platform_server.Api.middlewares;
using social_network_platform_server.Application.Accounts;
using social_network_platform_server.Application.Contracts.Accounts.Interfaces;
using social_network_platform_server.Application.Contracts.Posts.Interfaces;
using social_network_platform_server.Application.Contracts.Repository.Interfaces;
using social_network_platform_server.Application.Posts;
using social_network_platform_server.Application.Repositorys;
using social_network_platform_server.Domain.Accounts;
using social_network_platform_server.Infrastructure.DbContexts;
using System.Text;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IAccountService, AccountService>();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(optons =>
{
    optons.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(option =>
    {
        option.SaveToken = true;
        option.RequireHttpsMetadata = false;
        option.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = configuration["JWT:ValidIssuer"],
            ValidAudience = configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])) 
        };
    });

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("log.txt")
    .CreateLogger();

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app is not null)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();

app.MapControllers();
app.Run();
