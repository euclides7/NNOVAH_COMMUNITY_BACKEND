using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class License : BaseEntity
    {
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte []  File { get; set; }
        public int Client { get; set; }
        public bool ForClient { get; set; }
        public int Renewer { get; set; }
        public int QtRenewer { get; set; }
        public int LicenseConfig { get; set; }
        public int Terminal { get; set; }
        public int Package { get; set; }
        public int State { get; set; }
    }  
}
