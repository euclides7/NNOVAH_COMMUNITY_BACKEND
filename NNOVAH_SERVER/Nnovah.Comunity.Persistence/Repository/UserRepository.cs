using Microsoft.EntityFrameworkCore;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Domain;
using Nnovah.Comunity.Persistence.DatabaseContext;


namespace Nnovah.Comunity.Persistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository 
    {
        public UserRepository(NnovahComunityDatabaseContext context) : base(context)
        {
        }

        public async Task<User?> GetByPartnerAndCodeAsync(int idPartner, string userCode)
        {
            return await _context.User
                .FirstOrDefaultAsync(u => u.IdPartner == idPartner && u.UserCode == userCode);
        }
    }
    }

