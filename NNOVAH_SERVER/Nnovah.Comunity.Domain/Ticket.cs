using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class Ticket : BaseEntity
    {
        public string Description { get; set; }
        public string Urgency { get; set; }
        public int Partner { get; set; }
        public string SoftVersion { get; set; }
        public int Package { get; set; }
        public int Ticketstate { get; set; }
 

    }   
}
