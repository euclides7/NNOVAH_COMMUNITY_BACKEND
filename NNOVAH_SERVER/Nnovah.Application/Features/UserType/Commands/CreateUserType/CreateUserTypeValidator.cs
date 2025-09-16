using FluentValidation;
using Nnovah.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.UserType.Commands.CreateUserType
{
    public class CreateUserTypeValidator : AbstractValidator<CreateUserTypeCommand>
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public CreateUserTypeValidator(IUserTypeRepository userTypeRepository)
        {
            RuleFor(p=>p.Description).NotEmpty();
            this._userTypeRepository = userTypeRepository;
        }
    }
}
