using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class Partner : BaseEntity
    {
        public string Name { get; set; }
        public int Nif { get; set; }
        public string AddressId { get; set; }
        public string ContactId { get; set; }
        public int PartnerType { get; set; }

    }
}
