using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Nif { get; set; }
        public int CustomerNumber { get; set; }
        public int Partner { get; set; }
        public int State { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }

    }
}
