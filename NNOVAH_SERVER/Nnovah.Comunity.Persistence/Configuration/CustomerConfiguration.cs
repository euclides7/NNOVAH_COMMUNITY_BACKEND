using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nnovah.Comunity.Domain;

namespace Nnovah.Comunity.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            Console.WriteLine(">>> CustomerConfiguration carregada <<<");
            builder.HasOne(c => c.PartnerEntity)
                .WithMany()
                .HasForeignKey(c => c.Partner)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Contact)
                .WithMany()
                .HasForeignKey(c => c.ContactId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
