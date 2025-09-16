using FluentValidation;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Region.Commands.CreateRegion
{
    public class CreateRegionValidator:AbstractValidator<CreateRegionCommand>
    {
        private readonly IRegionRepository _regionRepository;

        public CreateRegionValidator(IRegionRepository regionRepository)
        {
            RuleFor(p => p.Description)
          .NotEmpty();
            this._regionRepository = regionRepository;
        }
    }
}
