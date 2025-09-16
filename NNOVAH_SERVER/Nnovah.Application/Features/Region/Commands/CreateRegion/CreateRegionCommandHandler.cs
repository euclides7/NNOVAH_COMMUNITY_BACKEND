using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;
using Nnovah.Comunity.Application.Features.Customer.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Region.Commands.CreateRegion
{
    public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;

        public CreateRegionCommandHandler(IMapper mapper,IRegionRepository regionRepository)
        {
            this._mapper = mapper;
            this._regionRepository = regionRepository;
        }
        public async Task<int> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRegionValidator(_regionRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);

            var region = _mapper.Map<Domain.Region>(request);
            await _regionRepository.CreatAsync(region);
            return region.Id;
        }
    }
}
