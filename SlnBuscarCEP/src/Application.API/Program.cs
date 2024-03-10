using Application.Service.Integracao;
using Application.Service.SQLServer;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Infra.Data.Repository.Data;
using Infra.Data.Repository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Refit;
using System.Text;

const string SECRET_KEY = "9fbbdd98-f2f4-4673-b48e-083ec1be44dc";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer("Server=LAPTOP-EBG33A6E\\SQLEXPRESS;Database=BuscarCep;User Id=sa;Password=gibi2016;TrustServerCertificate=True;Encrypt=False;"));


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Dependency Injection
builder.Services.AddScoped<ICepService, CepService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddRefitClient<ICepRepository>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://viacep.com.br");
});

//config autenticação
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = "yasminvic",
        ValidAudience = "buscar_cep",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY))

    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();