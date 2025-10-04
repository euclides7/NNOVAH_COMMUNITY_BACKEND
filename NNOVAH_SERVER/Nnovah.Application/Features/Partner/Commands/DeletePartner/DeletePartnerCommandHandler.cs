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

namespace Nnovah.Comunity.Application.Features.Partner.Commands.DeletePartner
{
    public class DeletePartnerCommandHandler : IRequestHandler<DeletePartnerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IContactsRepository _contactsRepository;
        private readonly ICustomerRepository _customerRepository;

        public DeletePartnerCommandHandler(IMapper mapper,IPartnerRepository partnerRepository,IAddressRepository addressRepository,
            IContactsRepository contactsRepository,ICustomerRepository customerRepository)
        {
            this._mapper = mapper;
            this._partnerRepository = partnerRepository;
            this._addressRepository = addressRepository;
            this._contactsRepository = contactsRepository;
            this._customerRepository = customerRepository;
        }
        public async Task<Unit> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.GetByIdAsync(request.Id);
            //var customer = await _customerRepository.GetByIdAsync(request.Id);
            var address = await _addressRepository.GetByIdAsync(partner.AddressId);
            var contacts = await _contactsRepository.GetByIdAsync(partner.ContactId);
            if (partner == null)
                throw new NotFoundException(nameof(partner), request.Id);
            await _addressRepository.DeleteAsync(address);
            await _contactsRepository.DeleteAsync(contacts);
            await _partnerRepository.DeleteAsync(partner);
            return Unit.Value;
        }
    }
}
