using Microsoft.EntityFrameworkCore;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Domain;
using Nnovah.Comunity.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Persistence.Repository
{
    public class PartnerRepository : GenericRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(NnovahComunityDatabaseContext context) : base(context)
        {
        }

        public async Task<List<Partner>> GetByIdWithRelationsAsync(string id)
        {
            return await _context.Partner
               .Include(c => c.Address)
               .Include(c => c.Contact)
               .Where(c => c.Id == Convert.ToInt32(id))
               .ToListAsync();
        }
    }
}
