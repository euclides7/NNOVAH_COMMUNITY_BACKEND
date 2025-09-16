using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;

namespace Nnovah.Comunity.Application.Features.PartnerType.Commands.CreatePartnerType
{
    public class CreatePartnerTypeCommandHandler : IRequestHandler<CreatePartnerTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPartnerTypeRepository _partnerTypeRepository;

        public CreatePartnerTypeCommandHandler(IMapper mapper, IPartnerTypeRepository partnerTypeRepository)
        {
            this._mapper = mapper;
            this._partnerTypeRepository = partnerTypeRepository;
        }
        public async Task<int> Handle(CreatePartnerTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePartnerTypeValidator(_partnerTypeRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);

            var partnerType = _mapper.Map<Domain.PartnerType>(request);
            await _partnerTypeRepository.CreatAsync(partnerType);
            return partnerType.Id;
        }
    }
}
