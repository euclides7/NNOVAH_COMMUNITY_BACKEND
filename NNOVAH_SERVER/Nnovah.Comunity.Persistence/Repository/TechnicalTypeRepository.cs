using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Domain;
using Nnovah.Comunity.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Persistence.Repository
{
    public class TechnicalTypeRepository : GenericRepository<TechnicalType>, ITechnicalTypeRepository
    {
        public TechnicalTypeRepository(NnovahComunityDatabaseContext context) : base(context)
        {
        }
    }
}
