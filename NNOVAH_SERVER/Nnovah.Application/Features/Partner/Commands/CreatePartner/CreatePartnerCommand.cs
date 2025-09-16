using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Partner.Commands.CreatePartner
{
    public class CreatePartnerCommand:IRequest<int>
    {
        public string Name { get; set; }
        public int Nif { get; set; }
        public string AddressId { get; set; }
        public string ContactId { get; set; }
        public int PartnerType { get; set; }
    }
}
