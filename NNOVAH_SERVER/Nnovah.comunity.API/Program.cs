using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Nnovah.Comunity.Application;
using Nnovah.Comunity.Persistence;
using Nnovah.Comunity.Persistence.Security;
using Nnovah.Comunity.Infrastruture;
using Nnovah.Application;
using Nnovah.Comunity.Application.Contracts.Security;

var builder = WebApplication.CreateBuilder(args);
var jwtKey = Environment.GetEnvironmentVariable("Jwt__Key")
             ?? builder.Configuration["Jwt:Key"];
builder.Services.AddSingleton<IIdProtector>(sp =>
    new AesIdProtector(jwtKey.ToString()));
if (string.IsNullOrEmpty(jwtKey))
{
    throw new Exception("JWT Key não encontrada. Configure a variável de ambiente 'Jwt__Key' ou no appsettings.json em Jwt:Key.");
}

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastrutureServices(builder.Configuration);

builder.Services.AddControllers();

// 🔒 Configurar autenticação JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // podes ativar se tiveres issuer fixo
        ValidateAudience = false, // idem para audience
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", policy => policy.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("all");

// Swagger só em dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🚨 Importante: Autenticação tem que vir ANTES de Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
