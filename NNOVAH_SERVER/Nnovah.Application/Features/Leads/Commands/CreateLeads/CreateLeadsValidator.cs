using FluentValidation;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Leads.Commands.CreateLeads
{
    public class CreateLeadsValidator:AbstractValidator<CreateLeadsCommand>
    {

        private readonly ILeadsRepository  _leadsRepository;
        public CreateLeadsValidator(ILeadsRepository leadsRepository)
        {
            RuleFor(p => p.Nif)
                .NotEmpty();
            RuleFor(p => p.Name)
                .NotEmpty();
            RuleFor(p => p.Partner)
              .NotEmpty()
              .NotNull()
              .NotEqual(0);
            RuleFor(p => p.ContactId)
              .NotEmpty()
              .NotEqual(0); ;
            RuleFor(p => p.AddressId)
              .NotEmpty()
              .NotEqual(0); ;
            this._leadsRepository = leadsRepository;
        }
    }
}
