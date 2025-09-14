using AutoMapper;
using Nnovah.Application.Features.States.Queries.GetStates;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class StatesProfile: Profile
    {
        public StatesProfile()
        {
            CreateMap<States, StatesDTO>().ReverseMap();
        }
    }
}
