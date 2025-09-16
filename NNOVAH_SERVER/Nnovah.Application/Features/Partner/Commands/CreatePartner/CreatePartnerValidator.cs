using FluentValidation;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Partner.Commands.CreatePartner
{
    public class CreatePartnerValidator: AbstractValidator<CreatePartnerCommand>
    {
        private readonly IPartnerRepository _partnerRepository;

        public CreatePartnerValidator(IPartnerRepository partnerRepository)
        {
            RuleFor(p => p.Nif)
               .NotEmpty();
            RuleFor(p => p.Name)
                .NotEmpty();
            RuleFor(p => p.PartnerType)
              .NotEmpty()
              .NotNull()
              .NotEqual(0);
            RuleFor(p => p.ContactId)
              .NotEmpty();
        
            RuleFor(p => p.AddressId)
            .NotEmpty() ;
       
            this._partnerRepository = partnerRepository;
        }
    }
}
