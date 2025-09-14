using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class TechnicalPartner : BaseEntity
    {
        public string Name { get; set; }
        public int TypeTechnical { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }
        public int Partner { get; set; }
    }
}
