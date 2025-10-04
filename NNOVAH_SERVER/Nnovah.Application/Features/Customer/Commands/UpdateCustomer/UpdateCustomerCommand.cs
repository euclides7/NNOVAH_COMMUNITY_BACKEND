using MediatR;
using Nnovah.Application.Features.Partner.Queries.GetPartner;
using Nnovah.Comunity.Application.Features.Address.Queries.GetAddress;
using Nnovah.Comunity.Application.Features.Contacts.Queries.GetContacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nif { get; set; }
        public int CustomerNumber { get; set; }
        public int Partner { get; set; }
        public int State { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }
     
    }
}
