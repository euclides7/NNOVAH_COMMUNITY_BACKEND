using Microsoft.EntityFrameworkCore;
using Nnovah.Comunity.Domain;
using Nnovah.Comunity.Domain.Communs;
using Nnovah.Comunity.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Persistence.DatabaseContext
{
    public class NnovahComunityDatabaseContext: DbContext
    {
        public NnovahComunityDatabaseContext(DbContextOptions<NnovahComunityDatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TechnicalType> TechnicalType { get; set; }
        public DbSet<TechnicalPartner> TechnicalPartner { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<PermissionGroup> PermissionGroup { get; set; }
        public DbSet<PartnerType> PartnerType { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<LicenseOrder> LicenseOrder { get; set; }
        public DbSet<License> License { get; set; }
        public DbSet<Leads> Leads { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NnovahComunityDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        // obtem todos objectos da classe base e verifica se tem algum elemento  a entrar ou a ser modificado
        //change tracker nos permite saber exatamente o que esta a ser feito no objecto
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }   
    }
}
