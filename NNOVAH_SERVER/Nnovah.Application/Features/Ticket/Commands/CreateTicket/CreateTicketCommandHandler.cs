using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;
using Nnovah.Comunity.Application.Features.States.Commands.CreateStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Ticket.Commands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketCommandHandler(IMapper mapper, ITicketRepository ticketRepository)
        {
            this._mapper = mapper;
            this._ticketRepository = ticketRepository;
        }
        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTickectValidator(_ticketRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);
            var ticket = _mapper.Map<Domain.Ticket>(request);
            await _ticketRepository.CreatAsync(ticket);
            return ticket.Id;
        }
    }
}
