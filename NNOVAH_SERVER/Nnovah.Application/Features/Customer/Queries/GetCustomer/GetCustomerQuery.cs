using MediatR;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<List<CustomerDTO>>
    {
    }
}
