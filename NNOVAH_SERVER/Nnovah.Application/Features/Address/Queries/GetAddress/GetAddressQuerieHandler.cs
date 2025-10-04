using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Features.Contacts.Queries.GetContacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Address.Queries.GetAddress
{
    public class GetAddressQuerieHandler : IRequestHandler<GetAddressQuerie, List<AddressDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public GetAddressQuerieHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            this._mapper = mapper;
            this._addressRepository = addressRepository;
        }
        public async Task<List<AddressDTO>> Handle(GetAddressQuerie request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetAsync();
            return _mapper.Map<List<AddressDTO>>(address);
        }
    }
}
