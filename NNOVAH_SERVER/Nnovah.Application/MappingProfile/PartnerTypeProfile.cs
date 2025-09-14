using AutoMapper;
using Nnovah.Application.Features.PartnerType.Queries.GetPartnerType;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class PartnerTypeProfile:Profile
    {
        public PartnerTypeProfile()
        {
            CreateMap<PartnerType, PartnerTypeDTO>().ReverseMap();  
        }
    }
}
