using FluentValidation;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.TechnicalType.Commands.CreateTechnicalType
{
    public class CreateTechnicalTypeValidator : AbstractValidator<CreateTechnicalTypeCommand>
    {
        private readonly ITechnicalTypeRepository _technicalTypeRepository;

        public CreateTechnicalTypeValidator(ITechnicalTypeRepository technicalTypeRepository)
        {

            RuleFor(p => p.Description)
                    .NotEmpty();
        
            this._technicalTypeRepository = technicalTypeRepository;
        }
    }
}
