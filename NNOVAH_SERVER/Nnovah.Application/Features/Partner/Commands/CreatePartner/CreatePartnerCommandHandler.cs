using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;


namespace Nnovah.Comunity.Application.Features.Partner.Commands.CreatePartner
{
    public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;

        public CreatePartnerCommandHandler(IMapper mapper, IPartnerRepository partnerRepository)
        {
            this._mapper = mapper;
            this._partnerRepository = partnerRepository;
        }
        public async Task<int> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePartnerValidator(_partnerRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);

            var partner = _mapper.Map<Domain.Partner>(request);
            await _partnerRepository.CreatAsync(partner);
            return partner.Id;
        }
    }
}
