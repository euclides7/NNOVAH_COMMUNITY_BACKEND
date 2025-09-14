using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class States : BaseEntity
    {
        public string Description { get; set; }
        public int LicenseState { get; set; }
        public int LicenceOrderState { get; set; }
        public int LeadState { get; set; }
      

    }
}
