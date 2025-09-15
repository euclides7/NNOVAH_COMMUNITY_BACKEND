using FluentValidation;
using Nnovah.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.User.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserValidator(IUserRepository userRepository)
        {

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{propertyName }  must be fewer than 70 characters");
            RuleFor(p => p.Email)
           .NotEmpty().NotNull();
            RuleFor(p => p.Usertype).NotNull();
            RuleFor(p => p.UserCode)
                .NotEmpty().WithMessage("UserCode is required")
                .Matches("^[a-zA-Z0-9]+(\\.[a-zA-Z0-9]+)*$")
                .WithMessage("UserCode deve conter apenas letras, números e ponto (.) sem espaços ou caracteres especiais.")
                .MustAsync(BeUniqueUser).WithMessage("Já existe um utilizador com este UserCode neste Partner.");

            this._userRepository = userRepository;
        }
        private async Task<bool> BeUniqueUser(CreateUserCommand command, string userCode, CancellationToken cancellationToken)
        {
            var existing = await _userRepository.GetByPartnerAndCodeAsync(command.IdPartner, userCode);
            return existing == null;
        }
    }
}
