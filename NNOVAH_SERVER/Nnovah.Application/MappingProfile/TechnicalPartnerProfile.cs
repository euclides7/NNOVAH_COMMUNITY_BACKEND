using AutoMapper;
using Nnovah.Application.Features.TechnicalPartner.Queries.GetTechnicalPartner;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class TechnicalPartnerProfile: Profile
    {
        public TechnicalPartnerProfile()
        {
            CreateMap<TechnicalPartner,TechnicalPartnerDTO>().ReverseMap();
        }
    }
}
