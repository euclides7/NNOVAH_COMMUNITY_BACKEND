using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;
using Nnovah.Comunity.Application.Features.Address.Commands.CreateAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Contacts.Commands.CreateContacts
{
    public class CreateContactsCommandHandler : IRequestHandler<CreateContactsCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IContactsRepository _contactsRepository;

        public CreateContactsCommandHandler(IMapper mapper, IContactsRepository contactsRepository)
        {
            this._mapper = mapper;
            this._contactsRepository = contactsRepository;
        }
        public async Task<int> Handle(CreateContactsCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContactsValidator(_contactsRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);

            var contacts = _mapper.Map<Domain.Contacts>(request);
            await _contactsRepository.CreatAsync(contacts);
            return contacts.Id;
        }
    }
}
