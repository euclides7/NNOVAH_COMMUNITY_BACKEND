using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nnovah.Comunity.Application.Contracts.Persistenc.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// 👇 alias para evitar conflito com Microsoft.IdentityModel.JsonWebTokens
using JwtClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace Nnovah.Comunity.Persistence.Security
{
    public class JwtService: IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(int userId, string userCode, int idPartner)
        {
            // 🔑 Ler a chave do appsettings.json ou variáveis de ambiente
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);

            var creds = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );

            // 👇 Claims que vão dentro do token
            var claims = new List<Claim>
            {
                new Claim(JwtClaimNames.Sub, userId.ToString()),
                new Claim("userCode", userCode),
                new Claim("idPartner", idPartner.ToString())
            };

            // 📅 Tempo de expiração configurável
            var expiresMinutes = int.TryParse(_configuration["Jwt:ExpiresInMinutes"], out var exp) ? exp : 60;

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
