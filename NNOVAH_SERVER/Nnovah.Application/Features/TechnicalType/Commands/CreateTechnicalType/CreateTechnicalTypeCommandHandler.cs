using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;
using Nnovah.Comunity.Application.Features.TechnicalPartner.Commands.CreateTechnicalPartner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.TechnicalType.Commands.CreateTechnicalType
{
    public class CreateTechnicalTypeCommandHandler : IRequestHandler<CreateTechnicalTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ITechnicalTypeRepository _technicalTypeRepository;

        public CreateTechnicalTypeCommandHandler(IMapper mapper,ITechnicalTypeRepository technicalTypeRepository)
        {
            this._mapper = mapper;
            this._technicalTypeRepository = technicalTypeRepository;
        }
        public async Task<int> Handle(CreateTechnicalTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTechnicalTypeValidator(_technicalTypeRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);

            var technicalType = _mapper.Map<Domain.TechnicalType>(request);
            await _technicalTypeRepository.CreatAsync(technicalType);
            return technicalType.Id;
        }
    }
}
