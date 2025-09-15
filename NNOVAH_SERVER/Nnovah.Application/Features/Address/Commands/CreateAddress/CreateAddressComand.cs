using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Address.Commands.CreateAddress
{
    public class CreateAddressComand: IRequest<int>
    {
        public string Street { get; set; }
        public string Province { get; set; }
        public int Country { get; set; }
        public string Municipality { get; set; }
    }
}
