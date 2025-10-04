using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, List<CustomerDetailDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerDetailQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
        }
        public async Task<List<CustomerDetailDTO>> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdWithRelationsAsync(request.encryptedId);
            return _mapper.Map<List<CustomerDetailDTO>>(customer);
        }
    }
}
