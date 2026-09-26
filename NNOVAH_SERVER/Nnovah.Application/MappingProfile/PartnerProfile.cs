using AutoMapper;
using Nnovah.Application.Features.Partner.Queries.GetPartner;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerDetail;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerQuery;
using Nnovah.Comunity.Application.Features.Partner.Commands.CreatePartner;
using Nnovah.Comunity.Application.Features.Partner.Commands.DeletePartner;
using Nnovah.Comunity.Application.Features.Partner.Commands.UpdatePartner;
using Nnovah.Comunity.Application.Features.Partner.Queries.GetPartnerDetail;
using Nnovah.Comunity.Application.MappingResolvers;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.MappingProfile
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDTO>()
                .ForMember(dest => dest.EncryptedId,
                    opt => opt.MapFrom<GenericIdResolver<Partner>>());
            CreateMap<Partner, PartnerDetailDTO>()
                .ForMember(dest => dest.EncryptedId,
                     opt => opt.MapFrom<GenericIdResolver<Partner>>());
            CreateMap<CreatePartnerCommand, Partner>().ReverseMap();
            CreateMap<DeletePartnerCommand, Partner>().ReverseMap();
            CreateMap<UpdatePartnerCommand, Partner>().ReverseMap();
        }
    }
}
