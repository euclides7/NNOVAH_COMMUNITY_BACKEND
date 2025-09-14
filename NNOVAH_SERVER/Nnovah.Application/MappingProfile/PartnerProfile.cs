using AutoMapper;
using Nnovah.Application.Features.Partner.Queries.GetPartner;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class PartnerProfile: Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner,PartnerDTO>().ReverseMap();
        }
    }
}
