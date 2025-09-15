using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Nif { get; set; }
        public int CustomerNumber { get; set; }
        public int Partner { get; set; }
        public int State { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }
    }
}
