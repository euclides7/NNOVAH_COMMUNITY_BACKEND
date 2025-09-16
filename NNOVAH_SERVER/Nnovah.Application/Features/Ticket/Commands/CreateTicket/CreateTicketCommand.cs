using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Ticket.Commands.CreateTicket
{
    public class CreateTicketCommand:IRequest<int>
    {
        public string Description { get; set; }
        public int Urgency { get; set; }
        public int Partner { get; set; }
        public string SoftVersion { get; set; }
        public int Package { get; set; }
        public int Ticketstate { get; set; }
    }
}
