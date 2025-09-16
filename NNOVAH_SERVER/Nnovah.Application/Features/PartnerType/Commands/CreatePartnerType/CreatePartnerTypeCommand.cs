using MediatR;


namespace Nnovah.Comunity.Application.Features.PartnerType.Commands.CreatePartnerType
{
    public class CreatePartnerTypeCommand:IRequest<int>
    {
        public string Description { get; set; }
    }
}
