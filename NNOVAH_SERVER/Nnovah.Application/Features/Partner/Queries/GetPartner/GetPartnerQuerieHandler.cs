using AutoMapper;
using MediatR;
using Nnovah.Application.Features.Partner.Queries.GetPartner;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Features.Address.Queries.GetAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Partner.Queries.GetPartner
{
    public class GetPartnerQuerieHandler : IRequestHandler<GetPartnerQuerie, List<PartnerDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;

        public GetPartnerQuerieHandler(IMapper mapper, IPartnerRepository partnerRepository)
        {
            this._mapper = mapper;
            this._partnerRepository = partnerRepository;
        }
        public async Task<List<PartnerDTO>> Handle(GetPartnerQuerie request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.GetAsync();
            return _mapper.Map<List<PartnerDTO>>(partner);
        }
    }
}
