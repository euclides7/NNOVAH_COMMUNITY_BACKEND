using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Partner.Commands.UpdatePartner
{
    public record UpdatePartnerCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nif { get; set; }
        public int PartnerType { get; set; }
        public int State { get; set; }
    }
}
