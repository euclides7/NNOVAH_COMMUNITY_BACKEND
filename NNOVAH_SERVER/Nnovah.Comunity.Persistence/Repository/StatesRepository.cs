using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Domain;
using Nnovah.Comunity.Persistence.DatabaseContext;


namespace Nnovah.Comunity.Persistence.Repository
{
    public class StatesRepository : GenericRepository<States>, IStatesRepository
    {
        public StatesRepository(NnovahComunityDatabaseContext context) : base(context)
        {
        }
    }
}
