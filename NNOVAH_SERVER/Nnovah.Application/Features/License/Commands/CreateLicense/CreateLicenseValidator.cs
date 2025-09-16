using FluentValidation;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.License.Commands.CreateLicense
{
    public class CreateLicenseValidator:AbstractValidator<CreateLicenseCommand>
    {
        private readonly ILicenseRepository _licenseRepository;
        public CreateLicenseValidator(ILicenseRepository licenseRepository)
        {
            RuleFor(p => p.Client)
                .NotEmpty()
                .NotNull();
            RuleFor(p => p.ForClient)
                .NotEmpty().NotNull();
            RuleFor(p => p.Package)
              .NotEmpty()
              .NotNull()
              .NotEqual(0);
            RuleFor(p => p.startDate)
              .NotEmpty();
            RuleFor(p => p.EndDate)
              .NotEmpty() ;
            this._licenseRepository = licenseRepository;
        }
    }
}
