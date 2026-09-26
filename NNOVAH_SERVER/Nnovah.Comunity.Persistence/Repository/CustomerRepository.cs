using Microsoft.EntityFrameworkCore;
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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NnovahComunityDatabaseContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetByIdWithRelationsAsync(string id)
        {
            return await _context.Customer
                .Include(c => c.PartnerEntity)
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .Where(c => c.Id == Convert.ToInt32(id)) 
                .ToListAsync();
        }


        public async Task<List<Customer>> GetWithRelationsAsync()
        {
            return await _context.Customer
                .Include(c => c.PartnerEntity)
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .ToListAsync();
        }
    }
}
