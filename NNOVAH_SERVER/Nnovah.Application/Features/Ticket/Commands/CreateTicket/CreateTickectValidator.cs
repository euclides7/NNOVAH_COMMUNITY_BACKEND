using FluentValidation;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Features.States.Commands.CreateStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Ticket.Commands.CreateTicket
{
    public class CreateTickectValidator : AbstractValidator<CreateTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;
        public CreateTickectValidator(ITicketRepository ticketRepository)
        {
            RuleFor(p => p.Description)
                    .NotEmpty();
            this._ticketRepository = ticketRepository;

        }
    
    }
}
