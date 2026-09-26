using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class Partner : BaseEntity
    {
        public string Name { get; set; }
        public string Nif { get; set; }

        public int AddressId { get; set; }
        public int ContactId { get; set; }
        public int PartnerType { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contacts Contact { get; set; }

    }
}
