using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
 

namespace Nnovah.Comunity.Application.Features.Partner.Queries.GetPartnerDetail
{
    public class GetPartnerDetailQuerieHandler : IRequestHandler<GetPartnerDetailQuerie, List<PartnerDetailDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;

        public GetPartnerDetailQuerieHandler(IMapper mapper, IPartnerRepository partnerRepository)
        {
            this._mapper = mapper;
            this._partnerRepository = partnerRepository;
        }
        public async Task<List<PartnerDetailDTO>> Handle(GetPartnerDetailQuerie request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.GetByIdWithRelationsAsync(request.encryptedId);
            return _mapper.Map<List<PartnerDetailDTO>>(partner);
        }
    }
}
