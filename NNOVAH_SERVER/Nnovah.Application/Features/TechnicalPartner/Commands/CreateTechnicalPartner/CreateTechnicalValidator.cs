using FluentValidation;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.TechnicalPartner.Commands.CreateTechnicalPartner
{
    public class CreateTechnicalValidator : AbstractValidator<CreateTechnicalPartnerCommand>
    {
        private readonly ITechnicalPartnerRepository _technicalPartnerRepository;

        public CreateTechnicalValidator(ITechnicalPartnerRepository technicalPartnerRepository)
        {

            RuleFor(p => p.Partner)
                    .NotEmpty(); 
            RuleFor(p => p.Name)
                    .NotEmpty(); 
            RuleFor(p => p.TypeTechnical)
                    .NotEmpty();
         
            this._technicalPartnerRepository = technicalPartnerRepository;
        }
    }
}
