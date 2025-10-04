﻿using AutoMapper;
using Nnovah.Application.Features.Leads.Queries.GetLeads;
using Nnovah.Comunity.Application.Features.Leads.Commands.CreateLeads;
using Nnovah.Comunity.Domain;


namespace Nnovah.Application.MappingProfile
{
    public class LeadsProfile:Profile
    {
        public LeadsProfile()
        {
            CreateMap<Leads,LeadsDTO>().ReverseMap();
            CreateMap<CreateLeadsCommand,Leads>().ReverseMap();
        }
    }
}
