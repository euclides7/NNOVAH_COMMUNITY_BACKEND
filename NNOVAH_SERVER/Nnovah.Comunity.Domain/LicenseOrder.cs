using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class LicenseOrder : BaseEntity
    {
        public int Partner { get; set; }
        public int Client { get; set; }
        public int numberOrder { get; set; }
        public int State { get; set; }

    }
}
