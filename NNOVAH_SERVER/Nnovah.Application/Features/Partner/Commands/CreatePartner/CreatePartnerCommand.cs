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
        public string Nif { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }
        public int PartnerType { get; set; }
    }
}
