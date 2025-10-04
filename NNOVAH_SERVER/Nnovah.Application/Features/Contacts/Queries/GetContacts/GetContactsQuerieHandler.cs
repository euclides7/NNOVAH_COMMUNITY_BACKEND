using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Contacts.Queries.GetContacts
{
    public class GetContactsQuerieHandler : IRequestHandler<GetContactsQuerie, List<ContactsDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IContactsRepository _contactsRepository;

        public GetContactsQuerieHandler(IMapper mapper, IContactsRepository contactsRepository)
        {
            this._mapper = mapper;
            this._contactsRepository = contactsRepository;
        }
        public async Task<List<ContactsDTO>> Handle(GetContactsQuerie request, CancellationToken cancellationToken)
        {
            var contacts = await _contactsRepository.GetAsync();
            return _mapper.Map<List<ContactsDTO>>(contacts);
        }
    }
}
