using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerDetail
{
    public record GetCustomerDetailQuery(string encryptedId) : IRequest<List<CustomerDetailDTO>>
    {
      
    }
}
