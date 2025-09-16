using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;
using Nnovah.Comunity.Application.Features.Leads.Commands.CreateLeads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.TechnicalPartner.Commands.CreateTechnicalPartner
{
    public class CreateTechnicalPartnerCommandHandler : IRequestHandler<CreateTechnicalPartnerCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ITechnicalPartnerRepository _technicalPartnerRepository;

        public CreateTechnicalPartnerCommandHandler(IMapper mapper,ITechnicalPartnerRepository technicalPartnerRepository)
        {
            this._mapper = mapper;
            this._technicalPartnerRepository = technicalPartnerRepository;
        }

        public async Task<int> Handle(CreateTechnicalPartnerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTechnicalValidator(_technicalPartnerRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);

            var technical = _mapper.Map<Domain.TechnicalPartner>(request);
            await _technicalPartnerRepository.CreatAsync(technical);
            return technical.Id;
        }
    }
}
