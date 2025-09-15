using FluentValidation;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Address.Commands.CreateAddress
{
    internal class CreateAddressValidator: AbstractValidator<CreateAddressComand>
    {
        private readonly IAddressRepository _addressRepository;
        public CreateAddressValidator(IAddressRepository addressRepository)
        {
            RuleFor(p => p.Street)
                .NotEmpty().WithMessage("{PropertyStreet} is required")
                .NotNull();
            RuleFor(p => p.Municipality)
           .NotEmpty().NotNull();
            RuleFor(p => p.Province).NotNull();
            RuleFor(p => p.Country).NotNull();
            this._addressRepository = addressRepository;
        }
    }
}
