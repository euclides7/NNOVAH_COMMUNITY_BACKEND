using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Domain;


namespace Nnovah.Comunity.Application.Features.Partner.Commands.UpdatePartner
{
    public class UpdatePartnerCommandHandler : IRequestHandler<UpdatePartnerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;

        public UpdatePartnerCommandHandler(IMapper mapper, IPartnerRepository partnerRepository)
        {
            this._mapper = mapper;
            this._partnerRepository = partnerRepository;
        }
        public async Task<Unit> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.GetByIdAsync(request.Id);
            if (partner == null)
                throw new KeyNotFoundException($"Cliente {request.Id} não encontrado");
            _mapper.Map(request, partner);
            await _partnerRepository.UpdateAsync(partner);
            return Unit.Value;
        }
    }
}
