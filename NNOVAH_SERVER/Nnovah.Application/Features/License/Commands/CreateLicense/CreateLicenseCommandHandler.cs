using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;
using Nnovah.Comunity.Application.Features.Leads.Commands.CreateLeads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.License.Commands.CreateLicense
{
    public class CreateLicenseCommandHandler : IRequestHandler<CreateLicenseCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILicenseRepository _licenseRepository;

        public CreateLicenseCommandHandler(IMapper mapper,ILicenseRepository licenseRepository)
        {
            this._mapper = mapper;
            this._licenseRepository = licenseRepository;
        }
        public async Task<int> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLicenseValidator(_licenseRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);

            var license = _mapper.Map<Domain.License>(request);
            await _licenseRepository.CreatAsync(license);
            return license.Id;
        }
    }
}
