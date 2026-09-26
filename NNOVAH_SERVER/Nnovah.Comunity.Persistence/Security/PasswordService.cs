using Nnovah.Comunity.Application.Contracts.Persistenc.Security;

namespace Nnovah.Comunity.Persistence.Security
{
    internal class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
