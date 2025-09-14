using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.Features.Ticket.Queries.GetTicket
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Urgency { get; set; }
        public int Partner { get; set; }
        public string SoftVersion { get; set; }
        public int Package { get; set; }
        public int Ticketstate { get; set; }
        public int State { get; set; }
    }
}
