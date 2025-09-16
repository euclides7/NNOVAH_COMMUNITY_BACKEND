using FluentValidation;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.PartnerType.Commands.CreatePartnerType
{
    public class CreatePartnerTypeValidator : AbstractValidator<CreatePartnerTypeCommand>
    {
        private readonly IPartnerTypeRepository _partnerTypeRepository;
        public CreatePartnerTypeValidator(IPartnerTypeRepository partnerTypeRepository)
        {
        
            RuleFor(p => p.Description)
                    .NotEmpty();
      
            this._partnerTypeRepository = partnerTypeRepository;

        }
    }

}
