using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;

namespace Nnovah.Comunity.Application.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new KeyNotFoundException($"Cliente {request.Id} não encontrado");
            _mapper.Map(request, customer);
            await _customerRepository.UpdateAsync(customer);
            return Unit.Value;
        }
    }
}
