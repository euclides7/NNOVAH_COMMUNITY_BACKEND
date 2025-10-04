using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IContactsRepository _contactsRepository;

        public DeleteCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository,IAddressRepository addressRepository,IContactsRepository contactsRepository)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
            this._addressRepository = addressRepository;
            this._contactsRepository = contactsRepository;
        }
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            var address = await _addressRepository.GetByIdAsync(customer.AddressId);
            var contacts = await _contactsRepository.GetByIdAsync(customer.ContactId);
            if (customer == null)
                throw new NotFoundException(nameof(customer), request.Id);
            await _addressRepository.DeleteAsync(address);
            await _contactsRepository.DeleteAsync(contacts);
            await _customerRepository.DeleteAsync(customer);
            return Unit.Value;
        }
    }
}
