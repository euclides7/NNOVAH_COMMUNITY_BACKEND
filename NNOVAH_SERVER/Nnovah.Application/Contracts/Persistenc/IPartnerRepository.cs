using Nnovah.Comunity.Domain;

namespace Nnovah.Comunity.Application.Contracts.Persistenc
{
    public interface IPartnerRepository : IGenericRepository<Partner>
    {
        Task<List<Partner>> GetByIdWithRelationsAsync(string id);
    }
}
