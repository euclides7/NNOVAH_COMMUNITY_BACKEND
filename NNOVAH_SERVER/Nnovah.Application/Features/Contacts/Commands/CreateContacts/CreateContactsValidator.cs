using FluentValidation;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Contacts.Commands.CreateContacts
{
    internal class CreateContactsValidator:AbstractValidator<CreateContactsCommand>
    {
        private readonly IContactsRepository _contactsRepository;
        public CreateContactsValidator(IContactsRepository contactsRepository)
        {
            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("{PropertyPhone} is required");
               
            this._contactsRepository = contactsRepository;
        }
    
}
}
