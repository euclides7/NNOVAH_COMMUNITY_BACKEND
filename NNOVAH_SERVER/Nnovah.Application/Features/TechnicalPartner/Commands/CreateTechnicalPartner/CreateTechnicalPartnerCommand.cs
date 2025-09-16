

using MediatR;

namespace Nnovah.Comunity.Application.Features.TechnicalPartner.Commands.CreateTechnicalPartner
{
    public class CreateTechnicalPartnerCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Nif { get; set; }
        public int TypeTechnical { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }
        public int Partner { get; set; }    
    }
}
