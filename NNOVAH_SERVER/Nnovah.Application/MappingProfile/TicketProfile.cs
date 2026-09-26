using AutoMapper;
using Nnovah.Application.Features.Ticket.Queries.GetTicket;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class TicketProfile:Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket,TicketDTO>().ReverseMap();

        }
    }
}
