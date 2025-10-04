using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Domain;

namespace Nnovah.Application.Contracts.Persistenc
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<List<Customer>> GetWithRelationsAsync();
        Task<List<Customer>> GetByIdWithRelationsAsync(string id);

    }
}
