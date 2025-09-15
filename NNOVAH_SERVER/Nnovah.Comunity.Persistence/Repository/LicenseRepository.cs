using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Domain;
using Nnovah.Comunity.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Persistence.Repository
{
    public class LicenseRepository : GenericRepository<Domain.License>, ILicenseRepository
    {
        public LicenseRepository(NnovahComunityDatabaseContext context) : base(context)
        {
        }
    }
}
