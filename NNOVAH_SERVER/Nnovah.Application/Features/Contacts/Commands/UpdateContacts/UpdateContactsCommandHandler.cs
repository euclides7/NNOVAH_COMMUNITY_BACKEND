using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Contacts.Commands.UpdateContacts
{
    public class UpdateContactsCommandHandler : IRequestHandler<UpdateContactsCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IContactsRepository _contactsRepository;

        public UpdateContactsCommandHandler(IMapper mapper, IContactsRepository contactsRepository)
        {
            this._mapper = mapper;
            this._contactsRepository = contactsRepository;
        }
        public async Task<Unit> Handle(UpdateContactsCommand request, CancellationToken cancellationToken)
        {
            var existing = await _contactsRepository.GetByIdAsync(request.Id);
            if (existing == null)
                throw new KeyNotFoundException($"contacts {request.Id} not found");
            _mapper.Map(request, existing);
            await _contactsRepository.UpdateAsync(existing);
            return Unit.Value;
        }
    }
}
