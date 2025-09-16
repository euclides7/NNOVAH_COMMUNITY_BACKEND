using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class States : BaseEntity
    {
        public string Description { get; set; }
        public bool LicenseState { get; set; }
        public bool LicenceOrderState { get; set; }
        public bool LeadState { get; set; }
      

    }
}
