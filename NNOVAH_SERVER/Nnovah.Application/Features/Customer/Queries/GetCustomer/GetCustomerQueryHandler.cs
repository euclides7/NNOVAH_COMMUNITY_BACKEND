using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerQuery;


namespace Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<CustomerDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(IMapper mapper,ICustomerRepository customerRepository)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
        }

        public async Task<List<CustomerDTO>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetWithRelationsAsync();
         
            return _mapper.Map<List<CustomerDTO>>(customer);
        }
    }
}
