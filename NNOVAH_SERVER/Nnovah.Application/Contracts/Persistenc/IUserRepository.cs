using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Domain;

namespace Nnovah.Application.Contracts.Persistenc
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByPartnerAndCodeAsync(int idPartner, string userCode);
    }
}
